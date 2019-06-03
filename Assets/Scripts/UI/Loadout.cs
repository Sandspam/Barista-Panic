using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loadout : MonoBehaviour
{
    public float delayBetweenBeingClicked;
    private float delayTimer;
    public GameObject lm_Slot;
    public GameObject rm_Slot;
    public GameObject q_Slot;
    public GameObject e_Slot;
    public GameObject r_Slot;
    public GameObject t_Slot;
    private bool wasClicked;
    private bool available;
    private GameObject confirmation;
    public bool tutorial;

    private void Awake()
    {
        if(tutorial)
        {
            GameObject.Find("HowToAssignAbilitiesDialogue").GetComponent<DialogueTrigger>().TriggerDialogue();
        }
        confirmation = GameObject.Find("Canvas").transform.GetChild(2).gameObject;
        delayTimer = delayBetweenBeingClicked;
        lm_Slot = GameObject.Find("Slot1");
        rm_Slot = GameObject.Find("Slot2");
        q_Slot = GameObject.Find("Slot3");
        e_Slot = GameObject.Find("Slot4");
        r_Slot = GameObject.Find("Slot5");
        t_Slot = GameObject.Find("Slot6");
        CheckIfAvailable();
        if(!available)
        {
            gameObject.GetComponent<Image>().color = Color.grey;
        }

        if(available)
        {
            gameObject.GetComponent<Image>().color = Color.white;
        }
    }

    private void Update()
    {
        if (wasClicked)
        {
            confirmation.SetActive(true);
            confirmation.GetComponentInChildren<Text>().text = "What key do you want to bind " + gameObject.transform.GetChild(0).name + " to?";
            delayTimer -= Time.deltaTime;

            if (delayTimer <= 0)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    //Then the ability gets set to Left Mouse
                    lm_Slot.GetComponentInChildren<Text>().text = gameObject.transform.GetChild(0).name;
                    DataHolder.LeftMouseWeapon = gameObject.transform.GetChild(0).name;
                    confirmation.SetActive(false);
                    wasClicked = false;
                }

                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    //Then the ability gets set to Right Mouse
                    rm_Slot.GetComponentInChildren<Text>().text = gameObject.transform.GetChild(0).name;
                    DataHolder.RightMouseWeapon = gameObject.transform.GetChild(0).name;
                    confirmation.SetActive(false);
                    wasClicked = false;
                }

                if (Input.GetKeyDown(KeyCode.Q))
                {
                    //Then the ability gets set to Q
                    q_Slot.GetComponentInChildren<Text>().text = gameObject.transform.GetChild(0).name;
                    DataHolder.QAbility = gameObject.transform.GetChild(0).name;
                    confirmation.SetActive(false);
                    wasClicked = false;
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    //Then the ability gets set to E
                    e_Slot.GetComponentInChildren<Text>().text = gameObject.transform.GetChild(0).name;
                    DataHolder.EAbility = gameObject.transform.GetChild(0).name;
                    confirmation.SetActive(false);
                    wasClicked = false;
                }

                if (Input.GetKeyDown(KeyCode.R))
                {
                    //Then the ability gets set to R
                    r_Slot.GetComponentInChildren<Text>().text = gameObject.transform.GetChild(0).name;
                    DataHolder.RAbility = gameObject.transform.GetChild(0).name;
                    confirmation.SetActive(false);
                    wasClicked = false;
                }

                if (Input.GetKeyDown(KeyCode.T))
                {
                    //Then the ability gets set to T
                    t_Slot.GetComponentInChildren<Text>().text = gameObject.transform.GetChild(0).name;
                    DataHolder.TAbility = gameObject.transform.GetChild(0).name;
                    confirmation.SetActive(false);
                    wasClicked = false;
                }
            }
        }
    }

    public void SetAbilityToKey ()
    {
        if(available)
            wasClicked = true;

        if (!available)
            Debug.Log("That item is not available!");
    }

    void CheckIfAvailable ()
    {
        if(gameObject.transform.GetChild(0).name == "Revolver")
        {
            if(DataHolder.RifleTier >= 1)
            {
                available = true;
            }
        }

        if (gameObject.transform.GetChild(0).name == "Shotgun")
        {
            if (DataHolder.ShotgunTier >= 1)
            {
                available = true;
            }
        }

        if (gameObject.transform.GetChild(0).name == "Grenade")
        {
            if (DataHolder.GrenadeTier >= 1)
            {
                available = true;
            }
        }

        if (gameObject.transform.GetChild(0).name == "Rapid Fire")
        {
            if (DataHolder.RapidFireTier >= 1)
            {
                available = true;
            }
        }

        if (gameObject.transform.GetChild(0).name == "Armor")
        {
            if (DataHolder.ArmorTier >= 1)
            {
                available = true;
            }
        }

        if (gameObject.transform.GetChild(0).name == "HP Fill")
        {
            if (DataHolder.HPFillTier >= 1)
            {
                available = true;
            }
        }

        if (gameObject.transform.GetChild(0).name == "Shield")
        {
            if (DataHolder.ShieldTier >= 1)
            {
                available = true;
            }
        }

        if (gameObject.transform.GetChild(0).name == "Speed")
        {
            if (DataHolder.SpeedTier >= 1)
            {
                available = true;
            }
        }
    }
}
