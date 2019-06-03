using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanPowerup : MonoBehaviour {

    //ice -- slow down movement speed
    //explosive -- aoe attack
    //greasy -- fire speed faster

    public string currentBean;
    public string[] beanTypes;
    public Color[] beanColors;
    private bool tutorial;

    private void Start()
    {
        tutorial = GameObject.Find("GameManager").GetComponent<WaveSpawn>().tutorial;
        currentBean = beanTypes[Random.Range(0, beanTypes.Length)];
        if(currentBean == "Ice")
        {
            //
            gameObject.GetComponentInChildren<SpriteRenderer>().color = beanColors[0];
        }

        if(currentBean == "Greasy")
        {
            //
            gameObject.GetComponentInChildren<SpriteRenderer>().color = beanColors[1];
        }

        if(currentBean == "Explosion")
        {
            //
            gameObject.GetComponentInChildren<SpriteRenderer>().color = beanColors[2];
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (GameObject.Find("BeanPickUpDialogue") != null)
            {
                GameObject.Find("BeanPickUpDialogue").GetComponent<DialogueTrigger>().TriggerDialogue();
            }
        }

        if (collision.tag == "Player")
        {
            if (currentBean == "Ice")
            {
                DataHolder.IceBean += 1;
                Destroy(gameObject);
            }

            if (currentBean == "Explosion")
            {
                DataHolder.ExplosionBean += 1;
                Destroy(gameObject);
            }

            if (currentBean == "Greasy")
            {
                DataHolder.GreasyBean += 1;
                Destroy(gameObject);
            }
        }
    }
}
