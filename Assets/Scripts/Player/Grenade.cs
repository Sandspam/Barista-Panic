using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float timeUntilExplosion;
    public int grenadeDamage;
    public GameObject explosion;
    private float explosionTimer;

    private void Start()
    {
        explosionTimer = timeUntilExplosion;
    }

    private void Update()
    {
        explosionTimer -= Time.deltaTime;

        if(explosionTimer <= 0)
        {
            GameObject explode = Instantiate(explosion, transform.position, Quaternion.identity);
            explode.GetComponent<Explosion>().explosionDamage = grenadeDamage;
            Destroy(gameObject);
        }
    }
}
