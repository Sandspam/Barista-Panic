using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KultistController : MonoBehaviour
{
    public enum State
    {
        CHASE,
        WALKTOWARDS,
        ATTACK,
        PURSUEBEAN,
        BEANATTACK,
        DODGE
    }

    //General Variables
    public State state;
    public GameObject player;
    public bool hasBean;
    private Animator anim;
    public float RMin;
    public float RMax;
    public float GMin;
    public float GMax;
    public float BMin;
    public float BMax;

    //Chase Variables
    public bool canMove;
    public float movementSpeed;
    public bool playerInRange;

    //Attack Variables
    public float pounceMovementSpeed;
    public float pounceCooldown;
    //public AnimationClip attackAnim;
    private float pounceTimer;
    //private float attackAnimTimer;

    //Pursue Bean Variables
    public float beanChaseSpeed;

    //Bean Attack Variables
    public string currentBean;
    public GameObject explosionPrefab;

    private void Start()
    {
        pounceTimer = pounceCooldown;
        player = GameObject.Find("Player");
        anim = gameObject.GetComponent<Animator>();
        //attackAnimTimer = attackAnim.length;

        RMin /= 255;
        RMax /= 255;
        GMin /= 255;
        GMax /= 255;
        BMin /= 255;
        BMax /= 255;
        gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(Random.Range(RMin, RMax), Random.Range(GMin, GMax), Random.Range(BMin, BMax), 255);
        GameObject.Find("KultistDialogue").GetComponent<DialogueTrigger>().TriggerDialogue();
    }

    private void Update()
    {
        switch(state)
        {
            case State.CHASE:
                Chase();
                break;

            case State.WALKTOWARDS:
                Walktowards();
                break;

            case State.ATTACK:
                Attack();
                break;

            case State.PURSUEBEAN:
                Pursuebean();
                break;

            case State.BEANATTACK:
                Beanattack();
                break;

            case State.DODGE:
                Dodge();
                break;
        }

        if(!hasBean && pounceTimer <= 0 && playerInRange)
        {
            state = State.ATTACK;
        }

        if(hasBean && pounceTimer <= 0 && playerInRange)
        {
            state = State.BEANATTACK;
        }

        pounceTimer -= Time.deltaTime;
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, player.transform.position - transform.position);

        if(GameObject.FindGameObjectsWithTag("Bean").Length > 0 && !hasBean)
        {
            state = State.PURSUEBEAN;
        }
    }

    void Chase ()
    {
        if (canMove)
        {
            //Vector3 dir = transform.position - player.transform.position;
            //gameObject.transform.Translate(dir * movementSpeed * Time.deltaTime);
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, movementSpeed);
        }

        if (!playerInRange)
            state = State.WALKTOWARDS;
    }

    void Walktowards ()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, -movementSpeed);
        if (playerInRange)
            state = State.CHASE;
    }

    void Attack ()
    {
        gameObject.transform.GetChild(2).gameObject.SetActive(true);
        transform.position = Vector2.MoveTowards(transform.position, gameObject.transform.GetChild(2).gameObject.GetComponent<PlayerPosCheck>().initPlayerPos, pounceMovementSpeed);
        anim.SetBool("attacking", true);
        if (new Vector2(gameObject.transform.position.x, gameObject.transform.position.y) == new Vector2(gameObject.transform.GetChild(2).gameObject.GetComponent<PlayerPosCheck>().initPlayerPos.x, gameObject.transform.GetChild(2).gameObject.GetComponent<PlayerPosCheck>().initPlayerPos.y))
        {
            gameObject.transform.GetChild(2).gameObject.SetActive(false);
            pounceTimer = pounceCooldown;
            anim.SetBool("attacking", false);
            state = State.CHASE;
        }

        /*anim.applyRootMotion = true;
        anim.SetBool("attacking", true);
        if (attackAnimTimer <= 0)
        {
            pounceTimer = pounceCooldown;
            attackAnimTimer = attackAnim.length;
            anim.SetBool("attacking", false);
            anim.applyRootMotion = false;
            state = State.CHASE;
        }*/
    }

    void Pursuebean()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Bean");
        for (var i = 0; i < gameObjects.Length; i++)
        {
            transform.position = Vector2.MoveTowards(transform.position, gameObjects[i].transform.position, beanChaseSpeed);
            if(gameObjects[i] != null)
            {
                if (new Vector2(gameObject.transform.position.x, gameObject.transform.position.y) == new Vector2(gameObjects[i].transform.position.x, gameObjects[i].transform.position.y))
                {
                    currentBean = gameObjects[i].GetComponent<BeanPowerup>().currentBean;
                    hasBean = true;
                    Destroy(gameObjects[i]);
                    state = State.WALKTOWARDS;
                }
            }
        }
    }

    void Beanattack ()
    {
        gameObject.transform.GetChild(1).gameObject.SetActive(true);
        transform.position = Vector2.MoveTowards(transform.position, gameObject.transform.GetChild(1).gameObject.GetComponent<PlayerPosCheck>().initPlayerPos, pounceMovementSpeed);
        if (new Vector2(gameObject.transform.position.x, gameObject.transform.position.y) == new Vector2(gameObject.transform.GetChild(1).gameObject.GetComponent<PlayerPosCheck>().initPlayerPos.x, gameObject.transform.GetChild(1).gameObject.GetComponent<PlayerPosCheck>().initPlayerPos.y))
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            if (currentBean == "Greasy")
            {
                pounceTimer = pounceCooldown / 3.5f;
                Debug.Log(pounceCooldown / 3.5f);
            }
            else
                pounceTimer = pounceCooldown;

            state = State.CHASE;
        }
    }

    //Need to work later
    void Dodge ()
    {

    }
}
