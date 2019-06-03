using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyController : MonoBehaviour {

    public enum State
    {
        PATROL,
        CHASE,
        ATTACK,
        DUMMY
    }

    //General Variables
    [HideInInspector] public GameObject player;
    [HideInInspector] public bool canMove;
    public State state;
    private Animator anim;
    public float slowDuration;
    private float slowTimer;

    //Pathing Variables
    [HideInInspector] public GameObject target;
    [HideInInspector] public GameObject objective;
    public float pathingMoveSpeed;
    Grid grid;
    Vector3[] path;
    private int targetIndex;

    //Combat Variables
    public GameObject combatTarget;
    public float combatMoveSpeed;
    public bool combatCooldownStarted;
    public float combatCooldown;
    private float combatCooldownTimer;

	void Start ()
    {
        slowTimer = slowDuration;
        canMove = true;
        combatCooldownTimer = combatCooldown;
        anim = gameObject.GetComponent<Animator>();
        combatMoveSpeed = 0.1f;
        pathingMoveSpeed = 0.08f;
        objective = GameObject.Find("Desk");
        player = GameObject.Find("Player");
        target = objective;
        if (state != State.DUMMY)
        {
            state = State.PATROL;
//            grid = GameObject.Find("A*").GetComponent<Grid>();
        }
//        PathRequestManager.RequestPath(transform.position, target.transform.position);
    }
	
	void Update ()
    {
        if(combatMoveSpeed != 0.1f || pathingMoveSpeed != 0.08f)
        {
            slowTimer -= Time.deltaTime;
            if(slowTimer <= 0)
            {
                combatMoveSpeed = 0.1f;
                pathingMoveSpeed = 0.08f;
                slowTimer = slowDuration;
            }
        }

        if(Time.timeScale == 0f)
        {
            canMove = false;
        }
        else
        {
            canMove = true;
        }

        Debug.Log(Time.timeScale);

        switch (state)
        {
            case State.PATROL:
                Patrol();
                break;

            case State.CHASE:
                Chase();
                break;

            case State.ATTACK:
                Attack();
                break;

            case State.DUMMY:
                Dummy();
                break;
        }

        transform.rotation = Quaternion.LookRotation(Vector3.forward, target.transform.position - transform.position);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            state = State.ATTACK;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            state = State.ATTACK;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            combatCooldownStarted = true;
        }
    }

    void Patrol ()
    {
        if (canMove)
        {
            /*
            Vector3 currentWaypoint = path[0];
            if(transform.position == currentWaypoint)
            {
                targetIndex++;
                if(targetIndex >= path.Length)
                {
                    return;
                }
                currentWaypoint = path[targetIndex];
            }*/
            
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, pathingMoveSpeed);
            if (target == player)
                state = State.CHASE;
        }
    }

    void Chase()
    {
        if (canMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, combatMoveSpeed);
            if (target == objective)
                state = State.PATROL;
        }
    }

    void Attack()
    {
        if(canMove)
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, 0.1f);

        anim.SetBool("IsAttacking", true);
        if (combatCooldownStarted)
        {
            canMove = false;
            anim.SetBool("IsAttacking", false);
            combatCooldownTimer -= 1 * Time.deltaTime;
            if (combatCooldownTimer <= 0)
            {
                state = State.CHASE;
                canMove = true;
                combatCooldownTimer = combatCooldown;
                combatCooldownStarted = false;
            }
        }
    }

    void Dummy ()
    {
        canMove = false;
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
    }
    /*
    void FindPath (Vector3 startPos, Vector3 targetPos)
    {
        Node startNode = grid.NodeFromWorldPoint(startPos);
        Node targetNode = grid.NodeFromWorldPoint(targetPos);

        Vector3[] waypoints = new Vector3[0];
        waypoints = RetracePath(startNode, targetNode);

        List<Node> openSet = new List<Node>();
        HashSet<Node> closedSet = new HashSet<Node>();
        openSet.Add(startNode);

        while(openSet.Count > 0)
        {
            Node currentNode = openSet[0];
            for (int i = 1; i < openSet.Count; i++)
            {
                if(openSet[i].fCost < currentNode.fCost || openSet[i].fCost == currentNode.fCost && openSet[i].hCost < currentNode.hCost)
                {
                    currentNode = openSet[i];
                }
            }

            openSet.Remove(currentNode);
            closedSet.Add(currentNode);

            if(currentNode == targetNode)
            {
                RetracePath(startNode, targetNode);
                return;
            }

            foreach (Node neighbor in grid.GetNeighbours(currentNode))
            {
                if(!neighbor.walkable || closedSet.Contains(neighbor))
                {
                    continue;
                }

                int newMovementCostToNeighbour = currentNode.gCost + GetDistance(currentNode, neighbor);
                if(newMovementCostToNeighbour < neighbor.gCost || !openSet.Contains(neighbor))
                {
                    neighbor.gCost = newMovementCostToNeighbour;
                    neighbor.hCost = GetDistance(neighbor, targetNode);
                    neighbor.parent = currentNode;

                    if(!openSet.Contains(neighbor))
                    {
                        openSet.Add(neighbor);
                    }
                }
            }
        }
    }

    Vector3[] RetracePath (Node startNode, Node endNode)
    {
        List<Node> path = new List<Node>();
        Node currentNode = endNode;

        while (currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }
        Vector3[] waypoints = SimplifyPath(path);
        path.Reverse();
        return waypoints;

    }

    Vector3[] SimplifyPath(List<Node> path)
    {
        List<Vector3> waypoints = new List<Vector3>();
        Vector2 directionOld = Vector2.zero;

        for (int i = 1; i < path.Count; i++)
        {
            Vector2 directionNew = new Vector2(path[i-1].gridX - path[i].gridX, path[i - 1].gridY - path[i].gridY);
            if(directionNew != directionOld)
            {
                waypoints.Add(path[i].worldPosition);
            }
            directionOld = directionNew;
        }
        return waypoints.ToArray();
    }

    int GetDistance(Node nodeA, Node nodeB)
    {
        int dstX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
        int dstY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

        if(dstX > dstY)
        {
            return 14*dstY + 10* (dstX-dstY);
        }
        return 14 * dstX + 10 * (dstY - dstX);
    }
    */
}
