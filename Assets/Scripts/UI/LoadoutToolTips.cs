using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadoutToolTips : MonoBehaviour
{
    public GameObject previewBox;
    public Sprite greandeSprite;
    public Sprite meleeSprite;
    public Sprite revolverSprite;
    public Sprite shotgunSprite;
    public Sprite shieldSprite;
    public Sprite rapidFireSprite;
    public Sprite hpFillSprite;
    public Sprite speedSprite;
    public GameObject descriptionBox;

    private void OnEnable()
    {
        descriptionBox = GameObject.Find("DescriptionBox");
    }

    public void ShowToolTip (string itemSelected)
    {
        if(itemSelected == "Grenade")
        {
            previewBox.GetComponent<SpriteRenderer>().sprite = greandeSprite;
            descriptionBox.GetComponent<Text>().text = "Throw a grenade a short distance before it blows up. Hitting multiple enemies in an area.";
        }

        if (itemSelected == "Melee")
        {
            previewBox.GetComponent<SpriteRenderer>().sprite = meleeSprite;
            descriptionBox.GetComponent<Text>().text = "Quickly slash out your knife in front of you to hit enemies.";
        }

        if (itemSelected == "Revolver")
        {
            previewBox.GetComponent<SpriteRenderer>().sprite = revolverSprite;
            descriptionBox.GetComponent<Text>().text = "A gun that shoots a single bullet that does a lot of damage but has a long delay between firing.";
        }

        if (itemSelected == "Shotgun")
        {
            previewBox.GetComponent<SpriteRenderer>().sprite = shotgunSprite;
            descriptionBox.GetComponent<Text>().text = "A gun that shoots three bullets in front of you that has the longest delay. Make sure to get up close!";
        }

        if (itemSelected == "Shield")
        {
            previewBox.GetComponent<SpriteRenderer>().sprite = shieldSprite;
        }

        if (itemSelected == "Rapid Fire")
        {
            previewBox.GetComponent<SpriteRenderer>().sprite = rapidFireSprite;
            descriptionBox.GetComponent<Text>().text = "A gun that shoots multiple bullets in quick succession that does little on it's own but add up quickly!";
        }

        if (itemSelected == "HPFill")
        {
            previewBox.GetComponent<SpriteRenderer>().sprite = hpFillSprite;
        }

        if (itemSelected == "Speed")
        {
            previewBox.GetComponent<SpriteRenderer>().sprite = speedSprite;
        }

    }

}
