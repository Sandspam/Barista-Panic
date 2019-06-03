using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float despawnTimer;
    private float despawnTimerTime;
    public float damage;
    public GameObject explosion;
    [HideInInspector] public bool ice;
    [HideInInspector] public bool explosionB;


    void Start ()
    {
        despawnTimerTime = despawnTimer;
	}
	
	void Update ()
    {
        despawnTimerTime -= Time.deltaTime;

        if(despawnTimerTime <= 0)
        {
            Destroy(gameObject);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            if (!ice && !explosionB)
            {
                collision.gameObject.GetComponentInParent<EnemyHealthManager>().currentHealth -= damage;
                Destroy(gameObject);
                //collision.gameObject.transform.parent.GetComponentInChildren<EnemyHealthBar>().ShowHealthBar();
            }

            if(ice)
            {
                collision.gameObject.GetComponentInParent<EnemyHealthManager>().currentHealth -= damage;
                if (collision.gameObject.GetComponentInParent<MeleeEnemyController>())
                {
                    collision.gameObject.GetComponentInParent<MeleeEnemyController>().combatMoveSpeed /= 2;
                    collision.gameObject.GetComponentInParent<MeleeEnemyController>().pathingMoveSpeed /= 2;
                }

                if(collision.gameObject.GetComponentInParent<BeanlinerController>())
                {
                    collision.gameObject.GetComponentInParent<BeanlinerController>().movementSpeed /= 2;
                }
                Destroy(gameObject);
            }

            if(explosionB)
            {
                GameObject explode = Instantiate(explosion, transform.position, Quaternion.identity);
                explode.GetComponent<Explosion>().explosionDamage = damage;
            }
        }

        
    }
}
