using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthManager : MonoBehaviour {

    public float currentHealth;
    public float maxHealth;
    public Image healthBar;
    public bool dropsBean;
    public GameObject Bean;
    private bool petIsPresent;

	void Start ()
    {
        if (GameObject.Find("Pet") != null)
        {
            petIsPresent = true;
        }
        currentHealth = maxHealth;	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(currentHealth <= 0)
        {
            if (petIsPresent)
            {
                GameObject.Find("Pet").GetComponent<PetController>().canMove = true;
                GameObject.Find("Pet").GetComponent<PetController>().state = PetController.State.FOLLOW;
            }

            if(dropsBean)
            {
                Instantiate(Bean, transform.GetChild(0).transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
            Debug.Log("Is Dead.");
        }

        healthBar.fillAmount = currentHealth / maxHealth;

    }
}
