using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    public float objectiveLives;

    private void Update()
    {
        if(objectiveLives <= 0)
        {
            GameObject.Find("GameManager").GetComponent<WaveSpawn>().EndGame(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            objectiveLives -= 1;
            Destroy(collision.gameObject.transform.parent.gameObject);
        }
    }
}