using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float explosionDamage;
    public float explosionDuration;
    private float durationTimer;
    public bool isAgainstPlayer;

    private void Start()
    {
        durationTimer = explosionDuration;
    }

    private void Update()
    {
        durationTimer -= Time.deltaTime;
        if(durationTimer <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && !isAgainstPlayer)
        {
            collision.gameObject.GetComponentInParent<EnemyHealthManager>().currentHealth -= explosionDamage;
        }

        if(collision.gameObject.tag == "Player" && isAgainstPlayer)
        {
            if(collision.gameObject.GetComponent<PlayerHealthManager>().armor > 0)
            collision.gameObject.GetComponent<PlayerHealthManager>().armor -= 1;

            if(collision.gameObject.GetComponent<PlayerHealthManager>().armor <= 0)
            {
                collision.gameObject.GetComponent<PlayerHealthManager>().currentHealth -= 1;
            }
        }
    }

    /*private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealthManager>().currentHealth -= explosionDamage;
        }
    }*/
}
