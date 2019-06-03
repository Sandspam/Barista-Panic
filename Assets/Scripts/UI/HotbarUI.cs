using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotbarUI : MonoBehaviour
{
    public GameObject lmb_Slot;
    public GameObject rmb_Slot;
    public GameObject e_Slot;
    public GameObject q_Slot;
    public GameObject r_Slot;
    public GameObject t_Slot;
    public GameObject eb_Slot;
    public GameObject number_Slot;

    public Sprite rifle;
    public Sprite shotgun;
    public Sprite melee;
    public Sprite shield;
    public Sprite grenade;
    public Sprite rapidFire;
    public Sprite armor;
    public Sprite hpFill;
    public Sprite speed;
    public Color[] beanColors;

    void Start ()
    {
        lmb_Slot = GameObject.Find("LeftMouseWeapon");
        rmb_Slot = GameObject.Find("RightMouseWeapon");
        e_Slot = GameObject.Find("EAbility");
        q_Slot = GameObject.Find("QAbility");
        r_Slot = GameObject.Find("RAbility");
        t_Slot = GameObject.Find("TAbility");
        eb_Slot = GameObject.Find("CurrentElementBean");
        number_Slot = eb_Slot.transform.GetChild(0).transform.GetChild(0).gameObject;
    }
	
	void Update ()
    {
        if (DataHolder.LeftMouseWeapon == "Revolver")
        {
            lmb_Slot.GetComponentInChildren<SpriteRenderer>().sprite = rifle;
        }

        if(DataHolder.LeftMouseWeapon == "Shotgun")
        {
            lmb_Slot.GetComponentInChildren<SpriteRenderer>().sprite = shotgun;
        }

        if(DataHolder.LeftMouseWeapon == "Melee")
        {
            lmb_Slot.GetComponentInChildren<SpriteRenderer>().sprite = melee;
        }

        if(DataHolder.LeftMouseWeapon == "Grenade")
        {
            lmb_Slot.GetComponentInChildren<SpriteRenderer>().sprite = grenade;
        }

        if(DataHolder.LeftMouseWeapon == "Rapid Fire")
        {
            lmb_Slot.GetComponentInChildren<SpriteRenderer>().sprite = rapidFire;
        }

        if(DataHolder.LeftMouseWeapon == "Shield")
        {
            lmb_Slot.GetComponentInChildren<SpriteRenderer>().sprite = shield;
        }

        if (DataHolder.RightMouseWeapon == "Revolver")
        {
            rmb_Slot.GetComponentInChildren<SpriteRenderer>().sprite = rifle;
        }

        if (DataHolder.RightMouseWeapon == "Shotgun")
        {
            rmb_Slot.GetComponentInChildren<SpriteRenderer>().sprite = shotgun;
        }

        if (DataHolder.RightMouseWeapon == "Melee")
        {
            rmb_Slot.GetComponentInChildren<SpriteRenderer>().sprite = melee;
        }

        if (DataHolder.RightMouseWeapon == "Grenade")
        {
            rmb_Slot.GetComponentInChildren<SpriteRenderer>().sprite = grenade;
        }

        if (DataHolder.RightMouseWeapon == "Rapid Fire")
        {
            rmb_Slot.GetComponentInChildren<SpriteRenderer>().sprite = rapidFire;
        }

        if (DataHolder.RightMouseWeapon == "Shield")
        {
            rmb_Slot.GetComponentInChildren<SpriteRenderer>().sprite = shield;
        }

        if(DataHolder.EAbility == "Armor")
        {
            e_Slot.GetComponentInChildren<SpriteRenderer>().sprite = armor;
        }

        if(DataHolder.EAbility == "HP Fill")
        {
            e_Slot.GetComponentInChildren<SpriteRenderer>().sprite = hpFill;
        }

        if(DataHolder.EAbility == "Speed")
        {
            e_Slot.GetComponentInChildren<SpriteRenderer>().sprite = speed;
        }

        if (DataHolder.QAbility == "Armor")
        {
            q_Slot.GetComponentInChildren<SpriteRenderer>().sprite = armor;
        }

        if (DataHolder.QAbility == "HP Fill")
        {
            q_Slot.GetComponentInChildren<SpriteRenderer>().sprite = hpFill;
        }

        if (DataHolder.QAbility == "Speed")
        {
            q_Slot.GetComponentInChildren<SpriteRenderer>().sprite = speed;
        }

        lmb_Slot.GetComponentInChildren<Text>().text = DataHolder.LeftMouseWeapon;
        rmb_Slot.GetComponentInChildren<Text>().text = DataHolder.RightMouseWeapon;
        e_Slot.GetComponentInChildren<Text>().text = DataHolder.EAbility;
        q_Slot.GetComponentInChildren<Text>().text = DataHolder.QAbility;
//        r_Slot.GetComponentInChildren<Text>().text = DataHolder.RAbility;
//        t_Slot.GetComponentInChildren<Text>().text = DataHolder.TAbility;
        eb_Slot.GetComponentInChildren<Text>().text = GameObject.Find("Player").GetComponent<Player>().currentBeanEquipped;
        if(GameObject.Find("Player").GetComponent<Player>().currentBeanEquipped == "Ice")
        {
            number_Slot.GetComponent<Text>().text = "" + DataHolder.IceBean;
            number_Slot.transform.parent.parent.gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().color = beanColors[0];
        }

        if (GameObject.Find("Player").GetComponent<Player>().currentBeanEquipped == "Explosion")
        {
            number_Slot.GetComponent<Text>().text = "" + DataHolder.ExplosionBean;
            number_Slot.transform.parent.parent.gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().color = beanColors[1];
        }

        if (GameObject.Find("Player").GetComponent<Player>().currentBeanEquipped == "Greasy")
        {
            number_Slot.GetComponent<Text>().text = "" + DataHolder.GreasyBean;
            number_Slot.transform.parent.parent.gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().color = beanColors[2];
        }
    }
}
