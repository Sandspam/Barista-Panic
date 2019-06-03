using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{

    public int currentHealth;
    public int maxHealth;
    public int armor;

    void Start()
    {
        currentHealth = maxHealth;
        armor = DataHolder.ArmorPoints;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0 && armor <= 0)
        {
            GameObject.Find("GameManager").GetComponent<WaveSpawn>().EndGame(true);
            Destroy(gameObject);
        }
    }
}
