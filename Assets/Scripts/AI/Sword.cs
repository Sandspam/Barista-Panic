using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

    public int damageToGive;
    public bool meleeEnemy;
    public bool kultist;
    public bool pet;
    public float timeBetweenAttacks;
    private float timer;

    private void Start()
    {
        timer = timeBetweenAttacks;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (meleeEnemy)
        {
            if (collision.gameObject.tag == "Player")
            {
                if (collision.gameObject.GetComponentInParent<PlayerHealthManager>().armor >= 0)
                    collision.gameObject.GetComponentInParent<PlayerHealthManager>().armor -= damageToGive;

                if (collision.gameObject.GetComponentInParent<PlayerHealthManager>().armor <= 0)
                    collision.gameObject.GetComponentInParent<PlayerHealthManager>().currentHealth -= damageToGive;
            }
        }

        if(pet)
        {
            if(collision.gameObject.tag == "Enemy" && timer <= 0)
            {
                collision.gameObject.GetComponentInParent<EnemyHealthManager>().currentHealth -= damageToGive;
                timer = timeBetweenAttacks;
                collision.gameObject.transform.parent.GetComponentInChildren<EnemyHealthBar>().ShowHealthBar();
            }
        }

        if(kultist)
        {
            if (collision.gameObject.tag == "Player")
            {
                if (collision.gameObject.GetComponentInParent<PlayerHealthManager>().armor >= 0)
                    collision.gameObject.GetComponentInParent<PlayerHealthManager>().armor -= damageToGive;

                if (collision.gameObject.GetComponentInParent<PlayerHealthManager>().armor <= 0)
                    collision.gameObject.GetComponentInParent<PlayerHealthManager>().currentHealth -= damageToGive;

                if (gameObject.transform.parent.gameObject.GetComponent<KultistController>().currentBean == "Explosion")
                {
                    GameObject expInstance = Instantiate(gameObject.transform.parent.GetComponent<KultistController>().explosionPrefab, gameObject.transform.position, Quaternion.identity);
                    expInstance.GetComponent<Explosion>().isAgainstPlayer = true;
                    Destroy(gameObject.transform.parent.gameObject);
                }

                if (gameObject.transform.parent.gameObject.GetComponent<KultistController>().currentBean == "Ice")
                {
                    GameObject.Find("Player").GetComponent<Player>().moveSpeed /= 2;
                }
            }
        }
    }
}
