using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour 
{
    public int projectileDamage;
    public float projectileSpeed = 20;
    public float despawnTimer;

    private void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = (GameObject.Find("Player").transform.position - gameObject.transform.position).normalized * projectileSpeed;
    }

    private void Update()
    {
        despawnTimer -= Time.deltaTime;

        if(despawnTimer <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponentInParent<PlayerHealthManager>().currentHealth -= projectileDamage;
        }
    }
}
