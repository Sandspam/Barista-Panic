using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyController : MonoBehaviour {

    public float shotPause;
    private float shotPauseTimer;
    public GameObject projectile;
    public float projectileSpeed;
    public Transform projectileSpawn;
    private GameObject player;
    public float movementSpeed;
    public float moveTime;
    private float moveTimer;
    [HideInInspector] public bool playerInRange;
    private bool canMove;

    private void Start()
    {
        moveTimer = moveTime;
        shotPauseTimer = shotPause;
        player = GameObject.Find("PlayerBody");
    }

    private void Update()
    {
        if (Time.timeScale == 0f)
        {
            canMove = false;
        }
        else
        {
            canMove = true;
        }

        if (playerInRange)
        {
            RunAway();
        }

        if(!playerInRange)
        {
            Shoot();
        }
    }

    void RunAway ()
    {
        if (canMove)
        {
            moveTimer -= Time.deltaTime;
            Vector3 dir = transform.position - player.transform.position;
            gameObject.transform.Translate(dir * movementSpeed * Time.deltaTime);
            if (moveTimer <= 0)
            {
                ShootWhileMoving();
                moveTimer = moveTime;
            }
        }
    }

    void Shoot ()
    {
        shotPauseTimer -= Time.deltaTime;

        if (shotPauseTimer <= 0)
        {
            Instantiate(projectile, projectileSpawn.position, Quaternion.identity);
            shotPauseTimer = shotPause;
        }
    }

    void ShootWhileMoving ()
    {
        Instantiate(projectile, projectileSpawn.position, Quaternion.identity);
    }
}
