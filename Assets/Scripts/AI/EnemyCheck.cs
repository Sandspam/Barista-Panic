using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCheck : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy collided");
            gameObject.GetComponentInParent<PetController>().state = PetController.State.ATTACK;
            gameObject.GetComponentInParent<PetController>().combatTarget = collision.gameObject;
        }
    }
}
