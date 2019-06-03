using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stopper : MonoBehaviour {

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponentInParent<MeleeEnemyController>().canMove = false;
        }
        if(collision.gameObject.tag == "Pet")
        {
            collision.gameObject.GetComponentInParent<PetController>().canMove = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.gameObject.GetComponentInParent<MeleeEnemyController>().canMove = false;
        }
        if (collision.tag == "Pet")
        {
            collision.gameObject.GetComponentInParent<PetController>().canMove = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponentInParent<MeleeEnemyController>().canMove = true;
        }
        if (collision.gameObject.tag == "Pet")
        {
            collision.gameObject.GetComponentInParent<PetController>().canMove = true;
        }*/

    public bool isMeleeEnemy;
    public bool isPet;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(isMeleeEnemy)
                gameObject.GetComponentInParent<MeleeEnemyController>().canMove = false;

            if(isPet)
                gameObject.GetComponentInParent<PetController>().canMove = false;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            if (isPet)
            {
                gameObject.GetComponentInParent<PetController>().canMove = false;
                Debug.Log("Collided.");
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (isMeleeEnemy)
                gameObject.GetComponentInParent<MeleeEnemyController>().canMove = false;

            if (isPet)
                gameObject.GetComponentInParent<PetController>().canMove = false;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            if (isPet)
            {
                gameObject.GetComponentInParent<PetController>().canMove = false;
                Debug.Log("Collided.");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(isMeleeEnemy)
                gameObject.GetComponentInParent<MeleeEnemyController>().canMove = true;

            if (isPet)
            {
                gameObject.GetComponentInParent<PetController>().canMove = true;
                Debug.Log("Collided.");
            }
        }

        if(collision.gameObject.tag == "Enemy")
        {
            if (isPet)
                gameObject.GetComponentInParent<PetController>().canMove = true;
        }
    }

}
