using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUpgradeButton : MonoBehaviour
{
    //public int DataHolder.SpendCoins;

    public string whatButton;
    public bool[] armorTier;
    public bool[] speedTier;
    public bool[] HPFillTier;
    public bool[] rifleTier;
    public bool[] shotgunTier;
    public bool[] grenadeTier;
    public bool[] rapidFireTier;
    public bool[] shieldTier;

    public int tier1Cost;
    public int tier2Cost;
    public int tier3Cost;
    public int tier4Cost;

    public bool[] petHealTier;
    public bool[] petDamageTier;
    public bool[] petSpeedTier;
    public bool[] petMaxHealthTier;

    public Sprite active;
    private int defaultSpendCoins;

    private AudioSource aud;

    private void Start()
    {
        CheckTiers(whatButton);
        DataHolder.SpendCoins = DataHolder.Coins + DataHolder.TotalCoins;
        defaultSpendCoins = DataHolder.SpendCoins;
        aud = gameObject.transform.parent.gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        //GameObject.Find("CashText").GetComponent<Text>().text = "$" + DataHolder.SpendCoins;
    }

    //Need to make the armor consumable; You lose it when it breaks
    public void CheckTiers (string WhatButton)
    {
        if (WhatButton == "Armor")
        {
            if (DataHolder.ArmorTier == 1)
            {
                armorTier[0] = true;
                gameObject.transform.Find("Image1").GetComponent<SpriteRenderer>().sprite = active;
            }

            if (DataHolder.ArmorTier == 2)
            {
                armorTier[1] = true;
                gameObject.transform.Find("Image2").GetComponent<SpriteRenderer>().sprite = active;
            }
        }

        if (WhatButton == "HP Fill")
        {
            if (DataHolder.HPFillTier == 1)
            {
                HPFillTier[0] = true;
                gameObject.transform.Find("Image1").GetComponent<SpriteRenderer>().sprite = active;
            }

            if (DataHolder.HPFillTier == 2)
            {
                HPFillTier[1] = true;
                gameObject.transform.Find("Image2").GetComponent<SpriteRenderer>().sprite = active;
            }

            if (DataHolder.HPFillTier == 3)
            {
                HPFillTier[2] = true;
                gameObject.transform.Find("Image3").GetComponent<SpriteRenderer>().sprite = active;
            }

            if (DataHolder.HPFillTier == 4)
            {
                HPFillTier[3] = true;
                gameObject.transform.Find("Image4").GetComponent<SpriteRenderer>().sprite = active;
            }
        }

        if (WhatButton == "Rifle")
        {
            if (DataHolder.RifleTier == 1)
            {
                rifleTier[0] = true;
                gameObject.transform.Find("Image1").GetComponent<SpriteRenderer>().sprite = active;
            }

            if (DataHolder.RifleTier == 2)
            {
                rifleTier[1] = true;
                gameObject.transform.Find("Image2").GetComponent<SpriteRenderer>().sprite = active;
            }

            if (DataHolder.RifleTier == 3)
            {
                rifleTier[2] = true;
                gameObject.transform.Find("Image3").GetComponent<SpriteRenderer>().sprite = active;
            }

            if (DataHolder.RifleTier == 4)
            {
                rifleTier[3] = true;
                gameObject.transform.Find("Image4").GetComponent<SpriteRenderer>().sprite = active;
            }
        }

        if (WhatButton == "Shotgun")
        {
            if (DataHolder.ShotgunTier == 1)
            {
                shotgunTier[0] = true;
                gameObject.transform.Find("Image1").GetComponent<SpriteRenderer>().sprite = active;
            }

            if (DataHolder.ShotgunTier == 2)
            {
                shotgunTier[1] = true;
                gameObject.transform.Find("Image2").GetComponent<SpriteRenderer>().sprite = active;
            }

            if (DataHolder.ShotgunTier == 3)
            {
                shotgunTier[2] = true;
                gameObject.transform.Find("Image3").GetComponent<SpriteRenderer>().sprite = active;
            }

            if (DataHolder.ShotgunTier == 4)
            {
                shotgunTier[3] = true;
                gameObject.transform.Find("Image4").GetComponent<SpriteRenderer>().sprite = active;
            }
        }

        if (WhatButton == "Grenade")
        {
            if (DataHolder.GrenadeTier == 1)
            {
                grenadeTier[0] = true;
                gameObject.transform.Find("Image1").GetComponent<SpriteRenderer>().sprite = active;
            }

            if (DataHolder.GrenadeTier == 2)
            {
                grenadeTier[1] = true;
                gameObject.transform.Find("Image2").GetComponent<SpriteRenderer>().sprite = active;
            }

            if (DataHolder.GrenadeTier == 3)
            {
                grenadeTier[2] = true;
                gameObject.transform.Find("Image3").GetComponent<SpriteRenderer>().sprite = active;
            }

            if (DataHolder.GrenadeTier == 4)
            {
                grenadeTier[3] = true;
                gameObject.transform.Find("Image4").GetComponent<SpriteRenderer>().sprite = active;
            }
        }

        if (WhatButton == "Rapid Fire")
        {
            if (DataHolder.RapidFireTier == 1)
            {
                rapidFireTier[0] = true;
                gameObject.transform.Find("Image1").GetComponent<SpriteRenderer>().sprite = active;
            }

            if (DataHolder.RapidFireTier == 2)
            {
                rapidFireTier[1] = true;
                gameObject.transform.Find("Image2").GetComponent<SpriteRenderer>().sprite = active;
            }

            if (DataHolder.RapidFireTier == 3)
            {
                rapidFireTier[2] = true;
                gameObject.transform.Find("Image3").GetComponent<SpriteRenderer>().sprite = active;
            }

            if (DataHolder.RapidFireTier == 4)
            {
                rapidFireTier[3] = true;
                gameObject.transform.Find("Image4").GetComponent<SpriteRenderer>().sprite = active;
            }
        }

        if (WhatButton == "Shield")
        {
            if (DataHolder.ShieldTier == 1)
            {
                shieldTier[0] = true;
                gameObject.transform.Find("Image1").GetComponent<SpriteRenderer>().sprite = active;
            }

            if (DataHolder.ShieldTier == 2)
            {
                shieldTier[1] = true;
                gameObject.transform.Find("Image2").GetComponent<SpriteRenderer>().sprite = active;
            }

            if (DataHolder.ShieldTier == 3)
            {
                shieldTier[2] = true;
                gameObject.transform.Find("Image3").GetComponent<SpriteRenderer>().sprite = active;
            }

            if (DataHolder.ShieldTier == 4)
            {
                shieldTier[3] = true;
                gameObject.transform.Find("Image4").GetComponent<SpriteRenderer>().sprite = active;
            }
        }

        if (WhatButton == "Speed")
        {
            if (DataHolder.SpeedTier == 1)
            {
                speedTier[0] = true;
                gameObject.transform.Find("Image1").GetComponent<SpriteRenderer>().sprite = active;
            }

            if (DataHolder.SpeedTier == 2)
            {
                speedTier[1] = true;
                gameObject.transform.Find("Image2").GetComponent<SpriteRenderer>().sprite = active;
            }
        }
    }

    public void UpgradePlayerAbility (string abilityToUpgrade)
    {
        aud.Play();
        if (abilityToUpgrade == "Armor")
        {
            if(armorTier[0] == false && tier1Cost <= DataHolder.SpendCoins)
            {
                armorTier[0] = true;
                gameObject.transform.Find("Image1").GetComponent<SpriteRenderer>().sprite = active;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier1TooltipDesc.color = Color.green;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier1TooltipCost.color = Color.green;
                DataHolder.ArmorPoints = 3;
                DataHolder.ArmorTier = 1;
                DataHolder.SpendCoins -= tier1Cost;
            }

            else if (armorTier[1] == false && tier2Cost <= DataHolder.SpendCoins)
            {
                armorTier[1] = true;
                gameObject.transform.Find("Image2").GetComponent<SpriteRenderer>().sprite = active;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier2TooltipDesc.color = Color.green;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier2TooltipCost.color = Color.green;
                DataHolder.ArmorPoints = 4;
                DataHolder.ArmorTier = 2;
                DataHolder.SpendCoins -= tier2Cost;
            }

            /*else if (armorTier[2] == false && tier3Cost <= DataHolder.SpendCoins)
            {
                armorTier[2] = true;
                gameObject.transform.Find("Image3").GetComponent<SpriteRenderer>().sprite = active;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier3TooltipDesc.color = Color.green;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier3TooltipCost.color = Color.green;
                DataHolder.ArmorPoints = 5;
                DataHolder.ArmorTier = 3;
                DataHolder.SpendCoins -= tier3Cost;
            }

            else if (armorTier[3] == false && tier4Cost <= DataHolder.SpendCoins)
            {
                armorTier[3] = true;
                gameObject.transform.Find("Image4").GetComponent<SpriteRenderer>().sprite = active;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier4TooltipDesc.color = Color.green;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier4TooltipCost.color = Color.green;
                DataHolder.ArmorPoints = 6;
                DataHolder.ArmorTier = 4;
                DataHolder.SpendCoins -= tier4Cost;
            }*/
        }

        if (abilityToUpgrade == "HP Fill")
        {
            if(HPFillTier[0] == false && tier1Cost <= DataHolder.SpendCoins)
            {
                HPFillTier[0] = true;
                gameObject.transform.Find("Image1").GetComponent<SpriteRenderer>().sprite = active;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier1TooltipDesc.color = Color.green;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier1TooltipCost.color = Color.green;
                DataHolder.HealthToRestore = 1;
                DataHolder.HPFillTier = 1;
                DataHolder.SpendCoins -= tier1Cost;
            }

            else if (HPFillTier[1] == false && tier2Cost <= DataHolder.SpendCoins)
            {
                HPFillTier[1] = true;
                gameObject.transform.Find("Image2").GetComponent<SpriteRenderer>().sprite = active;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier2TooltipDesc.color = Color.green;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier2TooltipCost.color = Color.green;
                DataHolder.HealthToRestore = 2;
                DataHolder.HPFillTier = 1;
                DataHolder.SpendCoins -= tier2Cost;
            }

            else if (HPFillTier[2] == false && tier3Cost <= DataHolder.SpendCoins)
            {
                HPFillTier[2] = true;
                gameObject.transform.Find("Image3").GetComponent<SpriteRenderer>().sprite = active;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier3TooltipDesc.color = Color.green;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier3TooltipCost.color = Color.green;
                DataHolder.HealthToRestore = 3;
                DataHolder.HPFillTier = 1;
                DataHolder.SpendCoins -= tier3Cost;
            }

            else if (HPFillTier[3] == false && tier4Cost <= DataHolder.SpendCoins)
            {
                HPFillTier[3] = true;
                gameObject.transform.Find("Image4").GetComponent<SpriteRenderer>().sprite = active;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier4TooltipDesc.color = Color.green;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier4TooltipCost.color = Color.green;
                DataHolder.HealthToRestore = 4;
                DataHolder.HPFillTier = 1;
                DataHolder.SpendCoins -= tier4Cost;
            }
        }

        if (abilityToUpgrade == "Rifle")
        {
            if(rifleTier[0] == false && tier1Cost <= DataHolder.SpendCoins)
            {
                rifleTier[0] = true;
                gameObject.transform.Find("Image1").GetComponent<SpriteRenderer>().sprite = active;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier1TooltipDesc.color = Color.green;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier1TooltipCost.color = Color.green;
                DataHolder.RifleBulletDamage = 3;
                DataHolder.RifleTier = 1;
                DataHolder.SpendCoins -= tier1Cost;
            }

            else if (rifleTier[1] == false && tier2Cost <= DataHolder.SpendCoins)
            {
                rifleTier[1] = true;
                gameObject.transform.Find("Image2").GetComponent<SpriteRenderer>().sprite = active;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier2TooltipDesc.color = Color.green;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier2TooltipCost.color = Color.green;
                DataHolder.RifleBulletDamage = 4;
                DataHolder.RifleTier = 2;
                DataHolder.SpendCoins -= tier2Cost;
            }

            else if (rifleTier[2] == false && tier3Cost <= DataHolder.SpendCoins)
            {
                rifleTier[2] = true;
                gameObject.transform.Find("Image3").GetComponent<SpriteRenderer>().sprite = active;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier3TooltipDesc.color = Color.green;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier3TooltipCost.color = Color.green;
                DataHolder.RifleBulletDamage = 5;
                DataHolder.RifleTier = 3;
                DataHolder.SpendCoins -= tier3Cost;
            }

            else if (rifleTier[3] == false && tier4Cost <= DataHolder.SpendCoins)
            {
                rifleTier[3] = true;
                gameObject.transform.Find("Image4").GetComponent<SpriteRenderer>().sprite = active;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier4TooltipDesc.color = Color.green;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier4TooltipCost.color = Color.green;
                DataHolder.RifleBulletDamage = 4;
                DataHolder.RifleTier = 4;
                DataHolder.SpendCoins -= tier4Cost;
            }
        }

        if (abilityToUpgrade == "Shotgun")
        {
            if(shotgunTier[0] == false && tier1Cost <= DataHolder.SpendCoins)
            {
                shotgunTier[0] = true;
                gameObject.transform.Find("Image1").GetComponent<SpriteRenderer>().sprite = active;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier1TooltipDesc.color = Color.green;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier1TooltipCost.color = Color.green;
                DataHolder.ShotgunBulletDamage = 1;
                DataHolder.ShotgunTier = 1;
                DataHolder.SpendCoins -= tier1Cost;
            }

            else if (shotgunTier[1] == false && tier2Cost <= DataHolder.SpendCoins)
            {
                shotgunTier[1] = true;
                gameObject.transform.Find("Image2").GetComponent<SpriteRenderer>().sprite = active;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier2TooltipDesc.color = Color.green;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier2TooltipCost.color = Color.green;
                DataHolder.ShotgunBulletDamage = 2;
                DataHolder.ShotgunTier = 2;
                DataHolder.SpendCoins -= tier2Cost;
            }

            else if (shotgunTier[2] == false && tier3Cost <= DataHolder.SpendCoins)
            {
                shotgunTier[2] = true;
                gameObject.transform.Find("Image3").GetComponent<SpriteRenderer>().sprite = active;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier3TooltipDesc.color = Color.green;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier3TooltipCost.color = Color.green;
                DataHolder.ShotgunBulletDamage = 3;
                DataHolder.ShotgunTier = 3;
                DataHolder.SpendCoins -= tier3Cost;
            }

            else if (shotgunTier[3] == false && tier4Cost <= DataHolder.SpendCoins)
            {
                shotgunTier[3] = true;
                gameObject.transform.Find("Image4").GetComponent<SpriteRenderer>().sprite = active;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier4TooltipDesc.color = Color.green;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier4TooltipCost.color = Color.green;
                DataHolder.ShotgunBulletDamage = 4;
                DataHolder.ShotgunTier = 4;
                DataHolder.SpendCoins -= tier4Cost;
            }
        }

        if (abilityToUpgrade == "Grenade")
        {
            if(grenadeTier[0] == false && tier1Cost <= DataHolder.SpendCoins)
            {
                grenadeTier[0] = true;
                gameObject.transform.Find("Image1").GetComponent<SpriteRenderer>().sprite = active;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier1TooltipDesc.color = Color.green;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier1TooltipCost.color = Color.green;
                DataHolder.GrenadeDamage = 1;
                DataHolder.GrenadeTier = 1;
                DataHolder.SpendCoins -= tier1Cost;
            }

            else if (grenadeTier[1] == false && tier2Cost <= DataHolder.SpendCoins)
            {
                grenadeTier[1] = true;
                gameObject.transform.Find("Image2").GetComponent<SpriteRenderer>().sprite = active;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier2TooltipDesc.color = Color.green;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier2TooltipCost.color = Color.green;
                DataHolder.GrenadeDamage = 2;
                DataHolder.GrenadeTier = 2;
                DataHolder.SpendCoins -= tier2Cost;
            }

            else if (grenadeTier[2] == false && tier3Cost <= DataHolder.SpendCoins)
            {
                grenadeTier[2] = true;
                gameObject.transform.Find("Image3").GetComponent<SpriteRenderer>().sprite = active;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier3TooltipDesc.color = Color.green;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier3TooltipCost.color = Color.green;
                DataHolder.GrenadeDamage = 3;
                DataHolder.GrenadeTier = 3;
                DataHolder.SpendCoins -= tier3Cost;
            }

            else if (grenadeTier[3] == false && tier4Cost <= DataHolder.SpendCoins)
            {
                grenadeTier[3] = true;
                gameObject.transform.Find("Image4").GetComponent<SpriteRenderer>().sprite = active;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier4TooltipDesc.color = Color.green;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier4TooltipCost.color = Color.green;
                DataHolder.GrenadeDamage = 4;
                DataHolder.GrenadeTier = 4;
                DataHolder.SpendCoins -= tier4Cost;
            }
        }

        if (abilityToUpgrade == "Rapid Fire")
        {
            if(rapidFireTier[0] == false && tier1Cost <= DataHolder.SpendCoins)
            {
                rapidFireTier[0] = true;
                gameObject.transform.Find("Image1").GetComponent<SpriteRenderer>().sprite = active;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier1TooltipDesc.color = Color.green;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier1TooltipCost.color = Color.green;
                DataHolder.RapidFireBulletDamage = 0.5f;
                DataHolder.RapidFireTier = 1;
                DataHolder.SpendCoins -= tier1Cost;
            }

            else if (rapidFireTier[1] == false && tier2Cost <= DataHolder.SpendCoins)
            {
                rapidFireTier[1] = true;
                gameObject.transform.Find("Image2").GetComponent<SpriteRenderer>().sprite = active;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier2TooltipDesc.color = Color.green;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier2TooltipCost.color = Color.green;
                DataHolder.RapidFireBulletDamage = 1;
                DataHolder.RapidFireTier = 2;
                DataHolder.SpendCoins -= tier2Cost;
            }

            else if (rapidFireTier[2] == false && tier3Cost <= DataHolder.SpendCoins)
            {
                rapidFireTier[2] = true;
                gameObject.transform.Find("Image3").GetComponent<SpriteRenderer>().sprite = active;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier3TooltipDesc.color = Color.green;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier3TooltipCost.color = Color.green;
                DataHolder.RapidFireBulletDamage = 1.5f;
                DataHolder.RapidFireTier = 3;
                DataHolder.SpendCoins -= tier3Cost;
            }

            else if (rapidFireTier[3] == false && tier4Cost <= DataHolder.SpendCoins)
            {
                rapidFireTier[3] = true;
                gameObject.transform.Find("Image4").GetComponent<SpriteRenderer>().sprite = active;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier4TooltipDesc.color = Color.green;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier4TooltipCost.color = Color.green;
                DataHolder.RapidFireBulletDamage = 2;
                DataHolder.RapidFireTier = 4;
                DataHolder.SpendCoins -= tier4Cost;
            }
        }

        if (abilityToUpgrade == "Shield")
        {
            if(shieldTier[0] == false && tier1Cost <= DataHolder.SpendCoins)
            {
                shieldTier[0] = true;
                gameObject.transform.Find("Image1").GetComponent<SpriteRenderer>().sprite = active;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier1TooltipDesc.color = Color.green;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier1TooltipCost.color = Color.green;
                DataHolder.ShieldTier = 1;
                DataHolder.SpendCoins -= tier1Cost;
            }

            else if (shieldTier[1] == false && tier2Cost <= DataHolder.SpendCoins)
            {
                shieldTier[1] = true;
                gameObject.transform.Find("Image2").GetComponent<SpriteRenderer>().sprite = active;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier2TooltipDesc.color = Color.green;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier2TooltipCost.color = Color.green;
                DataHolder.ShieldTier = 2;
                DataHolder.SpendCoins -= tier2Cost;
            }

            else if (shieldTier[2] == false && tier3Cost <= DataHolder.SpendCoins)
            {
                shieldTier[2] = true;
                gameObject.transform.Find("Image3").GetComponent<SpriteRenderer>().sprite = active;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier3TooltipDesc.color = Color.green;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier3TooltipCost.color = Color.green;
                DataHolder.ShieldTier = 3;
                DataHolder.SpendCoins -= tier3Cost;
            }

            else if (shieldTier[3] == false && tier4Cost <= DataHolder.SpendCoins)
            {
                shieldTier[3] = true;
                gameObject.transform.Find("Image4").GetComponent<SpriteRenderer>().sprite = active;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier4TooltipDesc.color = Color.green;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier4TooltipCost.color = Color.green;
                DataHolder.ShieldTier = 4;
                DataHolder.SpendCoins -= tier4Cost;
            }
        }

        if (abilityToUpgrade == "Speed")
        {
            if (speedTier[0] == false && tier1Cost <= DataHolder.SpendCoins)
            {
                speedTier[0] = true;
                gameObject.transform.Find("Image1").GetComponent<SpriteRenderer>().sprite = active;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier1TooltipDesc.color = Color.green;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier1TooltipCost.color = Color.green;
                DataHolder.MovementSpeedIncrease = 1.10f;
                DataHolder.SpeedTier = 1;
                DataHolder.SpendCoins -= tier1Cost;
            }

            else if (speedTier[1] == false && tier2Cost <= DataHolder.SpendCoins)
            {
                speedTier[1] = true;
                gameObject.transform.Find("Image2").GetComponent<SpriteRenderer>().sprite = active;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier2TooltipDesc.color = Color.green;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier2TooltipCost.color = Color.green;
                DataHolder.MovementSpeedIncrease = 1.20f;
                DataHolder.SpeedTier = 2;
                DataHolder.SpendCoins -= tier2Cost;
            }
        }

        DataHolder.PendingCoins = Mathf.Abs(defaultSpendCoins - DataHolder.SpendCoins);
    }

    public void UpgradePetAbility (string abilityToUpgrade)
    {
        if(abilityToUpgrade == "Heal")
        {
            if(petHealTier[0] == false && tier1Cost <= DataHolder.SpendCoins)
            {
                petHealTier[0] = true;
                gameObject.transform.Find("Image1").GetComponent<SpriteRenderer>().sprite = active;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier1TooltipDesc.color = Color.green;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier1TooltipCost.color = Color.green;
                DataHolder.PetHealTier = 1;
                DataHolder.SpendCoins -= tier1Cost;
            }

            else if (petHealTier[1] == false && tier2Cost <= DataHolder.SpendCoins)
            {
                petHealTier[1] = true;
                gameObject.transform.Find("Image2").GetComponent<SpriteRenderer>().sprite = active;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier2TooltipDesc.color = Color.green;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier2TooltipCost.color = Color.green;
                DataHolder.PetHealTier = 2;
                DataHolder.SpendCoins -= tier2Cost;
            }

            else if (petHealTier[2] == false && tier3Cost <= DataHolder.SpendCoins)
            {
                petHealTier[2] = true;
                gameObject.transform.Find("Image3").GetComponent<SpriteRenderer>().sprite = active;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier3TooltipDesc.color = Color.green;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier3TooltipCost.color = Color.green;
                DataHolder.PetHealTier = 3;
                DataHolder.SpendCoins -= tier3Cost;
            }

            else if (petHealTier[3] == false && tier4Cost <= DataHolder.SpendCoins)
            {
                petHealTier[3] = true;
                gameObject.transform.Find("Image4").GetComponent<SpriteRenderer>().sprite = active;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier4TooltipDesc.color = Color.green;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier4TooltipCost.color = Color.green;
                DataHolder.PetHealTier = 4;
                DataHolder.SpendCoins -= tier4Cost;
            }
        }

        if(abilityToUpgrade == "Damage")
        {
            if (petDamageTier[0] == false)
            {
                petDamageTier[0] = true && tier1Cost <= DataHolder.SpendCoins;
                gameObject.transform.Find("Image1").GetComponent<SpriteRenderer>().sprite = active;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier1TooltipDesc.color = Color.green;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier1TooltipCost.color = Color.green;
                DataHolder.PetDamageTier = 1;
                DataHolder.SpendCoins -= tier1Cost;
            }

            else if (petDamageTier[1] == false)
            {
                petDamageTier[1] = true && tier2Cost <= DataHolder.SpendCoins;
                gameObject.transform.Find("Image2").GetComponent<SpriteRenderer>().sprite = active;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier2TooltipDesc.color = Color.green;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier2TooltipCost.color = Color.green;
                DataHolder.PetDamageTier = 2;
                DataHolder.SpendCoins -= tier2Cost;
            }

            else if (petDamageTier[2] == false)
            {
                petDamageTier[2] = true && tier3Cost <= DataHolder.SpendCoins;
                gameObject.transform.Find("Image3").GetComponent<SpriteRenderer>().sprite = active;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier3TooltipDesc.color = Color.green;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier3TooltipCost.color = Color.green;
                DataHolder.PetDamageTier = 3;
                DataHolder.SpendCoins -= tier3Cost;
            }

            else if (petDamageTier[3] == false)
            {
                petDamageTier[3] = true && tier4Cost <= DataHolder.SpendCoins;
                gameObject.transform.Find("Image4").GetComponent<SpriteRenderer>().sprite = active;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier4TooltipDesc.color = Color.green;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier4TooltipCost.color = Color.green;
                DataHolder.PetDamageTier = 4;
                DataHolder.SpendCoins -= tier4Cost;
            }
        }

        if(abilityToUpgrade == "Speed")
        {
            if (petSpeedTier[0] == false && tier1Cost <= DataHolder.SpendCoins)
            {
                petSpeedTier[0] = true;
                gameObject.transform.Find("Image1").GetComponent<SpriteRenderer>().sprite = active;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier1TooltipDesc.color = Color.green;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier1TooltipCost.color = Color.green;
                DataHolder.PetSpeedTier = 1;
                DataHolder.SpendCoins -= tier1Cost;
            }

            else if (petSpeedTier[1] == false && tier2Cost <= DataHolder.SpendCoins)
            {
                petSpeedTier[1] = true;
                gameObject.transform.Find("Image2").GetComponent<SpriteRenderer>().sprite = active;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier2TooltipDesc.color = Color.green;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier2TooltipCost.color = Color.green;
                DataHolder.PetSpeedTier = 2;
                DataHolder.SpendCoins -= tier2Cost;
            }

            else if (petSpeedTier[2] == false && tier3Cost <= DataHolder.SpendCoins)
            {
                petSpeedTier[2] = true;
                gameObject.transform.Find("Image3").GetComponent<SpriteRenderer>().sprite = active;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier3TooltipDesc.color = Color.green;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier3TooltipCost.color = Color.green;
                DataHolder.PetSpeedTier = 3;
                DataHolder.SpendCoins -= tier3Cost;
            }

            else if (petSpeedTier[3] == false && tier4Cost <= DataHolder.SpendCoins)
            {
                petSpeedTier[3] = true;
                gameObject.transform.Find("Image4").GetComponent<SpriteRenderer>().sprite = active;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier4TooltipDesc.color = Color.green;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier4TooltipCost.color = Color.green;
                DataHolder.PetSpeedTier = 4;
                DataHolder.SpendCoins -= tier4Cost;
            }
        }

        if(abilityToUpgrade == "MaxHealth")
        {
            if (petMaxHealthTier[0] == false && tier1Cost <= DataHolder.SpendCoins)
            {
                petMaxHealthTier[0] = true;
                gameObject.transform.Find("Image1").GetComponent<SpriteRenderer>().sprite = active;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier1TooltipDesc.color = Color.green;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier1TooltipCost.color = Color.green;
                DataHolder.PetMaxHealthTier = 1;
                DataHolder.SpendCoins -= tier1Cost;
            }

            else if (petMaxHealthTier[1] == false && tier2Cost <= DataHolder.SpendCoins)
            {
                petMaxHealthTier[1] = true;
                gameObject.transform.Find("Image2").GetComponent<SpriteRenderer>().sprite = active;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier2TooltipDesc.color = Color.green;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier2TooltipCost.color = Color.green;
                DataHolder.PetMaxHealthTier = 2;
                DataHolder.SpendCoins -= tier2Cost;
            }

            else if (petMaxHealthTier[2] == false && tier3Cost <= DataHolder.SpendCoins)
            {
                petMaxHealthTier[2] = true;
                gameObject.transform.Find("Image3").GetComponent<SpriteRenderer>().sprite = active;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier3TooltipDesc.color = Color.green;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier3TooltipCost.color = Color.green;
                DataHolder.PetMaxHealthTier = 3;
                DataHolder.SpendCoins -= tier3Cost;
            }

            else if (petMaxHealthTier[3] == false && tier4Cost <= DataHolder.SpendCoins)
            {
                petMaxHealthTier[3] = true;
                gameObject.transform.Find("Image4").GetComponent<SpriteRenderer>().sprite = active;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier4TooltipDesc.color = Color.green;
                gameObject.transform.parent.Find("GameManager").GetComponent<MouseOver>().Tier4TooltipCost.color = Color.green;
                DataHolder.PetMaxHealthTier = 4;
                DataHolder.SpendCoins -= tier4Cost;
            }
        }
    }
}
