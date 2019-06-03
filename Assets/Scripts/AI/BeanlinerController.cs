using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanlinerController : MonoBehaviour {

    public GameObject target;
    public float movementSpeed;
    public float slowDuration;
    public GameObject warning;
    private Vector3 warningPosition;
    private float slowTimer;
    public float warnDuration;
    private float warnTimer;
    private bool warn;
    private GameObject instance;
    private bool tutorial;
    public bool canMove = true;

	void Start () 
    {
        warnTimer = warnDuration;
        slowTimer = slowDuration;
        movementSpeed = 0.21f;
        target = GameObject.Find("Desk");
        transform.rotation = Quaternion.LookRotation(Vector3.forward, target.transform.position - transform.position);
        warn = true;
        tutorial = GameObject.Find("GameManager").GetComponent<WaveSpawn>().tutorial;
        canMove = true;
    }
	
	void Update () 
    {
        if(GameObject.Find("BeanlinerIntroDialogue") != null)
        {
            GameObject.Find("BeanlinerIntroDialogue").GetComponent<DialogueTrigger>().TriggerDialogue();
        }

        if(Time.timeScale < 1f)
        {
            canMove = false;
        }
        else
        {
            canMove = true;
        }

        if(warn)
        {
            warnDuration -= Time.deltaTime;
            if (warnDuration <= 0)
            {
                Destroy(instance);
                warn = false;
            }
        }
        if(canMove)
        {
            if (!warn)
            {
                if (movementSpeed != 0.21)
                {
                    slowTimer -= Time.deltaTime;
                    if (slowTimer <= 0)
                    {
                        movementSpeed = 0.21f;
                        slowTimer = slowDuration;
                    }
                }
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, movementSpeed);
                transform.rotation = Quaternion.LookRotation(Vector3.forward, target.transform.position - transform.position);
            }
        }
    }

    public void Warn(Vector3 pos)
    {
        instance = Instantiate(warning, new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
        warn = true;
    }
}
