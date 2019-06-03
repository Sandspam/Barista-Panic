using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetController : MonoBehaviour
{
    public enum State
    {
        FOLLOW,
        ATTACK,
        HEAL
    }

    public State state = State.FOLLOW;
    public GameObject player;
    public float movementSpeed;
    public GameObject combatTarget;
    public float healCooldown;
    public float timeBetweenAttacks;
    public AnimationClip attackAnimation;
    private float attackTimer;
    private float healTimer;
    private float attackAnimationTimer;
    private Animator anim;
    public bool canMove;
    private GameObject target;
    private float moveSpeed;

    private void Start()
    {
        attackAnimationTimer = attackAnimation.length;
        attackTimer = timeBetweenAttacks;
        canMove = true;
        player = GameObject.Find("Player");
        healTimer = healCooldown;
        anim = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        Debug.Log(canMove);
        if (Time.timeScale == 0f)
        {
            canMove = false;
        }

        switch (state)
        {
            case State.ATTACK:
                Attack();
                break;

            case State.FOLLOW:
                Follow();
                break;

            case State.HEAL:
                Heal();
                break;
        }
        if(canMove)
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed);

        healTimer -= Time.deltaTime;
    }

    void Follow ()
    {
        target = player;
        moveSpeed = 0.05f;

        /*
        if (canMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 0.05f);
        }

        if(!canMove)
        {
            Debug.Log("Can't move");
        }*/

        if(player.GetComponent<PlayerHealthManager>().currentHealth <= 3)
        {
            state = State.HEAL;
        }

        transform.rotation = Quaternion.LookRotation(Vector3.forward, player.transform.position - transform.position);
    }

    void Attack ()
    {
        moveSpeed = 0.1f;
        attackTimer -= Time.deltaTime;
        /*
        if (canMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, combatTarget.transform.position, 0.1f);
        }*/

        target = combatTarget;

        if(combatTarget == null)
        {
            anim.SetBool("IsAttacking", false);
            canMove = true;
            state = State.FOLLOW;
        }

        if (attackTimer <= 0)
        {
            anim.SetBool("IsAttacking", true);
            attackAnimationTimer -= Time.deltaTime;
            if (attackAnimationTimer <= 0)
            {
                attackTimer = timeBetweenAttacks;
                anim.SetBool("IsAttacking", false);
                attackAnimationTimer = attackAnimation.length;
            }
        }

        transform.rotation = Quaternion.LookRotation(Vector3.forward, combatTarget.transform.position - transform.position);
    }

    void Heal ()
    {
        if(healTimer <= 0)
        {
            player.GetComponent<PlayerHealthManager>().currentHealth += DataHolder.PetHeal;
            healTimer = healCooldown;
        }

        state = State.FOLLOW;
    }
}
