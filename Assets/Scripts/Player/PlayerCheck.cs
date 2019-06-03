using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheck : MonoBehaviour {

    public bool meleeEnemy;
    public MeleeEnemyController melee;
    public bool rangedEnemy;
    public RangedEnemyController ranged;
    public bool kultist;
    public KultistController kk;

    private void Start()
    {
        if(meleeEnemy)
            melee = gameObject.GetComponentInParent<MeleeEnemyController>();

        if (rangedEnemy)
            ranged = gameObject.GetComponentInParent<RangedEnemyController>();

        if (kultist)
            kk = gameObject.GetComponentInParent<KultistController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(meleeEnemy)
                melee.target = melee.player;

            if (rangedEnemy)
                ranged.playerInRange = true;

            if (kultist)
                kk.playerInRange = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(meleeEnemy)
                melee.target = melee.player;

            if (rangedEnemy)
                ranged.playerInRange = true;

            if (kultist)
                kk.playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(meleeEnemy)
                melee.target = melee.objective;

            if (rangedEnemy)
                ranged.playerInRange = false;

            if (kultist)
                kk.playerInRange = false;
        }
    }
}
