using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseOver : MonoBehaviour
{
    public Text Tier1TooltipDesc;
    public Text Tier1TooltipCost;
    public Text Tier2TooltipDesc;
    public Text Tier2TooltipCost;
    public Text Tier3TooltipDesc;
    public Text Tier3TooltipCost;
    public Text Tier4TooltipDesc;
    public Text Tier4TooltipCost;

    private void Start()
    {
        Tier1TooltipDesc = GameObject.Find("Tier1ToolTipDescription").GetComponent<Text>();
        Tier1TooltipCost = GameObject.Find("Tier1ToolTipCost").GetComponent<Text>();
        Tier2TooltipDesc = GameObject.Find("Tier2ToolTipDescription").GetComponent<Text>();
        Tier2TooltipCost = GameObject.Find("Tier2ToolTipCost").GetComponent<Text>();
        Tier3TooltipDesc = GameObject.Find("Tier3ToolTipDescription").GetComponent<Text>();
        Tier3TooltipCost = GameObject.Find("Tier3ToolTipCost").GetComponent<Text>();
        Tier4TooltipDesc = GameObject.Find("Tier4ToolTipDescription").GetComponent<Text>();
        Tier4TooltipCost = GameObject.Find("Tier4ToolTipCost").GetComponent<Text>();
    }

    public void ShowToolTip (string typeOfUpgrade)
    {
        if(typeOfUpgrade == "Armor")
        {
            Tier1TooltipDesc.text = "Tier 1 (Passive): Armor takes 3 hits to destroy.";
            Tier1TooltipCost.text = "Cost: $" + gameObject.transform.parent.GetChild(3).GetComponent<ShopUpgradeButton>().tier1Cost;
            Tier2TooltipDesc.text = "Tier 2 (Passive): Armor takes 4 hits to destroy.";
            Tier2TooltipCost.text = "Cost: $" + gameObject.transform.parent.GetChild(3).GetComponent<ShopUpgradeButton>().tier2Cost;
            Tier3TooltipDesc.text = "";
            Tier3TooltipCost.text = "";// + gameObject.transform.parent.GetChild(4).GetComponent<ShopUpgradeButton>().tier3Cost;
            Tier4TooltipDesc.text = "";
            Tier4TooltipCost.text = "";// + gameObject.transform.parent.GetChild(4).GetComponent<ShopUpgradeButton>().tier4Cost;

            if(DataHolder.ArmorTier == 0)
            {
                Tier1TooltipDesc.color = Color.white;
                Tier1TooltipCost.color = Color.white;
                Tier2TooltipDesc.color = Color.white;
                Tier2TooltipCost.color = Color.white;
                Tier3TooltipDesc.color = Color.white;
                Tier3TooltipCost.color = Color.white;
                Tier4TooltipDesc.color = Color.white;
                Tier4TooltipCost.color = Color.white;
            }

            if(DataHolder.ArmorTier == 1)
            {
                Tier1TooltipDesc.color = Color.green;
                Tier1TooltipCost.color = Color.green;
                Tier2TooltipDesc.color = Color.white;
                Tier2TooltipCost.color = Color.white;
                Tier3TooltipDesc.color = Color.white;
                Tier3TooltipCost.color = Color.white;
                Tier4TooltipDesc.color = Color.white;
                Tier4TooltipCost.color = Color.white;
            }

            if (DataHolder.ArmorTier == 2)
            {
                Tier1TooltipDesc.color = Color.green;
                Tier1TooltipCost.color = Color.green;
                Tier2TooltipDesc.color = Color.green;
                Tier2TooltipCost.color = Color.green;
                Tier3TooltipDesc.color = Color.white;
                Tier3TooltipCost.color = Color.white;
                Tier4TooltipDesc.color = Color.white;
                Tier4TooltipCost.color = Color.white;
            }

            if (DataHolder.ArmorTier == 3)
            {
                Tier1TooltipDesc.color = Color.green;
                Tier1TooltipCost.color = Color.green;
                Tier2TooltipDesc.color = Color.green;
                Tier2TooltipCost.color = Color.green;
                Tier3TooltipDesc.color = Color.green;
                Tier3TooltipCost.color = Color.green;
                Tier4TooltipDesc.color = Color.white;
                Tier4TooltipCost.color = Color.white;
            }

            if (DataHolder.ArmorTier == 4)
            {
                Tier1TooltipDesc.color = Color.green;
                Tier1TooltipCost.color = Color.green;
                Tier2TooltipDesc.color = Color.green;
                Tier2TooltipCost.color = Color.green;
                Tier3TooltipDesc.color = Color.green;
                Tier3TooltipCost.color = Color.green;
                Tier4TooltipDesc.color = Color.green;
                Tier4TooltipCost.color = Color.green;
            }
        }

        if (typeOfUpgrade == "HP Fill")
        {
            Tier1TooltipDesc.text = "Tier 1: Fills 1 HP.";
            Tier1TooltipCost.text = "Cost: $" + gameObject.transform.parent.GetChild(4).GetComponent<ShopUpgradeButton>().tier1Cost;
            Tier2TooltipDesc.text = "Tier 2: Fills 2 HP.";
            Tier2TooltipCost.text = "Cost: $" + gameObject.transform.parent.GetChild(4).GetComponent<ShopUpgradeButton>().tier2Cost;
            Tier3TooltipDesc.text = "Tier 3: Fills 3 HP.";
            Tier3TooltipCost.text = "Cost: $" + gameObject.transform.parent.GetChild(4).GetComponent<ShopUpgradeButton>().tier3Cost;
            Tier4TooltipDesc.text = "Tier 4: Fills 4 HP.";
            Tier4TooltipCost.text = "Cost: $" + gameObject.transform.parent.GetChild(4).GetComponent<ShopUpgradeButton>().tier4Cost;

            if (DataHolder.HPFillTier == 0)
            {
                Tier1TooltipDesc.color = Color.white;
                Tier1TooltipCost.color = Color.white;
                Tier2TooltipDesc.color = Color.white;
                Tier2TooltipCost.color = Color.white;
                Tier3TooltipDesc.color = Color.white;
                Tier3TooltipCost.color = Color.white;
                Tier4TooltipDesc.color = Color.white;
                Tier4TooltipCost.color = Color.white;
            }

            if (DataHolder.HPFillTier == 1)
            {
                Tier1TooltipDesc.color = Color.green;
                Tier1TooltipCost.color = Color.green;
                Tier2TooltipDesc.color = Color.white;
                Tier2TooltipCost.color = Color.white;
                Tier3TooltipDesc.color = Color.white;
                Tier3TooltipCost.color = Color.white;
                Tier4TooltipDesc.color = Color.white;
                Tier4TooltipCost.color = Color.white;
            }

            if (DataHolder.HPFillTier == 2)
            {
                Tier1TooltipDesc.color = Color.green;
                Tier1TooltipCost.color = Color.green;
                Tier2TooltipDesc.color = Color.green;
                Tier2TooltipCost.color = Color.green;
                Tier3TooltipDesc.color = Color.white;
                Tier3TooltipCost.color = Color.white;
                Tier4TooltipDesc.color = Color.white;
                Tier4TooltipCost.color = Color.white;
            }

            if (DataHolder.HPFillTier == 3)
            {
                Tier1TooltipDesc.color = Color.green;
                Tier1TooltipCost.color = Color.green;
                Tier2TooltipDesc.color = Color.green;
                Tier2TooltipCost.color = Color.green;
                Tier3TooltipDesc.color = Color.green;
                Tier3TooltipCost.color = Color.green;
                Tier4TooltipDesc.color = Color.white;
                Tier4TooltipCost.color = Color.white;
            }

            if (DataHolder.HPFillTier == 4)
            {
                Tier1TooltipDesc.color = Color.green;
                Tier1TooltipCost.color = Color.green;
                Tier2TooltipDesc.color = Color.green;
                Tier2TooltipCost.color = Color.green;
                Tier3TooltipDesc.color = Color.green;
                Tier3TooltipCost.color = Color.green;
                Tier4TooltipDesc.color = Color.green;
                Tier4TooltipCost.color = Color.green;
            }
        }

        if (typeOfUpgrade == "Rifle")
        {
            Tier1TooltipDesc.text = "Tier 1: Rifle's bullets do 3 damage.";
            Tier1TooltipCost.text = "Cost: $" + gameObject.transform.parent.GetChild(5).GetComponent<ShopUpgradeButton>().tier1Cost;
            Tier2TooltipDesc.text = "Tier 2: Rifle's bullets do 4 damage.";
            Tier2TooltipCost.text = "Cost: $" + gameObject.transform.parent.GetChild(5).GetComponent<ShopUpgradeButton>().tier2Cost;
            Tier3TooltipDesc.text = "Tier 3: Rifle's bullets do 5 damage.";
            Tier3TooltipCost.text = "Cost: $" + gameObject.transform.parent.GetChild(5).GetComponent<ShopUpgradeButton>().tier3Cost;
            Tier4TooltipDesc.text = "Tier 4: Rifle's bullets do 6 damage.";
            Tier4TooltipCost.text = "Cost: $" + gameObject.transform.parent.GetChild(5).GetComponent<ShopUpgradeButton>().tier4Cost;

            if (DataHolder.RifleTier == 0)
            {
                Tier1TooltipDesc.color = Color.white;
                Tier1TooltipCost.color = Color.white;
                Tier2TooltipDesc.color = Color.white;
                Tier2TooltipCost.color = Color.white;
                Tier3TooltipDesc.color = Color.white;
                Tier3TooltipCost.color = Color.white;
                Tier4TooltipDesc.color = Color.white;
                Tier4TooltipCost.color = Color.white;
            }

            if (DataHolder.RifleTier == 1)
            {
                Tier1TooltipDesc.color = Color.green;
                Tier1TooltipCost.color = Color.green;
                Tier2TooltipDesc.color = Color.white;
                Tier2TooltipCost.color = Color.white;
                Tier3TooltipDesc.color = Color.white;
                Tier3TooltipCost.color = Color.white;
                Tier4TooltipDesc.color = Color.white;
                Tier4TooltipCost.color = Color.white;
            }

            if (DataHolder.RifleTier == 2)
            {
                Tier1TooltipDesc.color = Color.green;
                Tier1TooltipCost.color = Color.green;
                Tier2TooltipDesc.color = Color.green;
                Tier2TooltipCost.color = Color.green;
                Tier3TooltipDesc.color = Color.white;
                Tier3TooltipCost.color = Color.white;
                Tier4TooltipDesc.color = Color.white;
                Tier4TooltipCost.color = Color.white;
            }

            if (DataHolder.RifleTier == 3)
            {
                Tier1TooltipDesc.color = Color.green;
                Tier1TooltipCost.color = Color.green;
                Tier2TooltipDesc.color = Color.green;
                Tier2TooltipCost.color = Color.green;
                Tier3TooltipDesc.color = Color.green;
                Tier3TooltipCost.color = Color.green;
                Tier4TooltipDesc.color = Color.white;
                Tier4TooltipCost.color = Color.white;
            }

            if (DataHolder.RifleTier == 4)
            {
                Tier1TooltipDesc.color = Color.green;
                Tier1TooltipCost.color = Color.green;
                Tier2TooltipDesc.color = Color.green;
                Tier2TooltipCost.color = Color.green;
                Tier3TooltipDesc.color = Color.green;
                Tier3TooltipCost.color = Color.green;
                Tier4TooltipDesc.color = Color.green;
                Tier4TooltipCost.color = Color.green;
            }
        }

        if (typeOfUpgrade == "Shotgun")
        {
            Tier1TooltipDesc.text = "Tier 1: Shotgun's bullets do 1 damage.";
            Tier1TooltipCost.text = "Cost: $" + gameObject.transform.parent.GetChild(6).GetComponent<ShopUpgradeButton>().tier1Cost;
            Tier2TooltipDesc.text = "Tier 2: Shotgun's bullets do 2 damage.";
            Tier2TooltipCost.text = "Cost: $" + gameObject.transform.parent.GetChild(6).GetComponent<ShopUpgradeButton>().tier2Cost;
            Tier3TooltipDesc.text = "Tier 3: Shotgun's bullets do 3 damage.";
            Tier3TooltipCost.text = "Cost: $" + gameObject.transform.parent.GetChild(6).GetComponent<ShopUpgradeButton>().tier3Cost;
            Tier4TooltipDesc.text = "Tier 4: Shotgun's bullets do 4 damage.";
            Tier4TooltipCost.text = "Cost: $" + gameObject.transform.parent.GetChild(6).GetComponent<ShopUpgradeButton>().tier4Cost;

            if (DataHolder.ShotgunTier == 0)
            {
                Tier1TooltipDesc.color = Color.white;
                Tier1TooltipCost.color = Color.white;
                Tier2TooltipDesc.color = Color.white;
                Tier2TooltipCost.color = Color.white;
                Tier3TooltipDesc.color = Color.white;
                Tier3TooltipCost.color = Color.white;
                Tier4TooltipDesc.color = Color.white;
                Tier4TooltipCost.color = Color.white;
            }

            if (DataHolder.ShotgunTier == 1)
            {
                Tier1TooltipDesc.color = Color.green;
                Tier1TooltipCost.color = Color.green;
                Tier2TooltipDesc.color = Color.white;
                Tier2TooltipCost.color = Color.white;
                Tier3TooltipDesc.color = Color.white;
                Tier3TooltipCost.color = Color.white;
                Tier4TooltipDesc.color = Color.white;
                Tier4TooltipCost.color = Color.white;
            }

            if (DataHolder.ShotgunTier == 2)
            {
                Tier1TooltipDesc.color = Color.green;
                Tier1TooltipCost.color = Color.green;
                Tier2TooltipDesc.color = Color.green;
                Tier2TooltipCost.color = Color.green;
                Tier3TooltipDesc.color = Color.white;
                Tier3TooltipCost.color = Color.white;
                Tier4TooltipDesc.color = Color.white;
                Tier4TooltipCost.color = Color.white;
            }

            if (DataHolder.ShotgunTier == 3)
            {
                Tier1TooltipDesc.color = Color.green;
                Tier1TooltipCost.color = Color.green;
                Tier2TooltipDesc.color = Color.green;
                Tier2TooltipCost.color = Color.green;
                Tier3TooltipDesc.color = Color.green;
                Tier3TooltipCost.color = Color.green;
                Tier4TooltipDesc.color = Color.white;
                Tier4TooltipCost.color = Color.white;
            }

            if (DataHolder.ShotgunTier == 4)
            {
                Tier1TooltipDesc.color = Color.green;
                Tier1TooltipCost.color = Color.green;
                Tier2TooltipDesc.color = Color.green;
                Tier2TooltipCost.color = Color.green;
                Tier3TooltipDesc.color = Color.green;
                Tier3TooltipCost.color = Color.green;
                Tier4TooltipDesc.color = Color.green;
                Tier4TooltipCost.color = Color.green;
            }
        }

        if (typeOfUpgrade == "Grenade")
        {
            Tier1TooltipDesc.text = "Tier 1: Grenades do 1 damage.";
            Tier1TooltipCost.text = "Cost: $" + gameObject.transform.parent.GetChild(7).GetComponent<ShopUpgradeButton>().tier1Cost;
            Tier2TooltipDesc.text = "Tier 2: Grenades do 2 damage.";
            Tier2TooltipCost.text = "Cost: $" + gameObject.transform.parent.GetChild(7).GetComponent<ShopUpgradeButton>().tier2Cost;
            Tier3TooltipDesc.text = "Tier 3: Grenades do 3 damage.";
            Tier3TooltipCost.text = "Cost: $" + gameObject.transform.parent.GetChild(7).GetComponent<ShopUpgradeButton>().tier3Cost;
            Tier4TooltipDesc.text = "Tier 4: Grenades do 4 damage.";
            Tier4TooltipCost.text = "Cost: $" + gameObject.transform.parent.GetChild(7).GetComponent<ShopUpgradeButton>().tier4Cost;

            if (DataHolder.GrenadeTier == 0)
            {
                Tier1TooltipDesc.color = Color.white;
                Tier1TooltipCost.color = Color.white;
                Tier2TooltipDesc.color = Color.white;
                Tier2TooltipCost.color = Color.white;
                Tier3TooltipDesc.color = Color.white;
                Tier3TooltipCost.color = Color.white;
                Tier4TooltipDesc.color = Color.white;
                Tier4TooltipCost.color = Color.white;
            }

            if (DataHolder.GrenadeTier == 1)
            {
                Tier1TooltipDesc.color = Color.green;
                Tier1TooltipCost.color = Color.green;
                Tier2TooltipDesc.color = Color.white;
                Tier2TooltipCost.color = Color.white;
                Tier3TooltipDesc.color = Color.white;
                Tier3TooltipCost.color = Color.white;
                Tier4TooltipDesc.color = Color.white;
                Tier4TooltipCost.color = Color.white;
            }

            if (DataHolder.GrenadeTier == 2)
            {
                Tier1TooltipDesc.color = Color.green;
                Tier1TooltipCost.color = Color.green;
                Tier2TooltipDesc.color = Color.green;
                Tier2TooltipCost.color = Color.green;
                Tier3TooltipDesc.color = Color.white;
                Tier3TooltipCost.color = Color.white;
                Tier4TooltipDesc.color = Color.white;
                Tier4TooltipCost.color = Color.white;
            }

            if (DataHolder.GrenadeTier == 3)
            {
                Tier1TooltipDesc.color = Color.green;
                Tier1TooltipCost.color = Color.green;
                Tier2TooltipDesc.color = Color.green;
                Tier2TooltipCost.color = Color.green;
                Tier3TooltipDesc.color = Color.green;
                Tier3TooltipCost.color = Color.green;
                Tier4TooltipDesc.color = Color.white;
                Tier4TooltipCost.color = Color.white;
            }

            if (DataHolder.GrenadeTier == 4)
            {
                Tier1TooltipDesc.color = Color.green;
                Tier1TooltipCost.color = Color.green;
                Tier2TooltipDesc.color = Color.green;
                Tier2TooltipCost.color = Color.green;
                Tier3TooltipDesc.color = Color.green;
                Tier3TooltipCost.color = Color.green;
                Tier4TooltipDesc.color = Color.green;
                Tier4TooltipCost.color = Color.green;
            }
        }

        if (typeOfUpgrade == "Rapid Fire")
        {
            Tier1TooltipDesc.text = "Tier 1: Rapid Fire's bullets do 0.5 damage.";
            Tier1TooltipCost.text = "Cost: $" + gameObject.transform.parent.GetChild(8).GetComponent<ShopUpgradeButton>().tier1Cost;
            Tier2TooltipDesc.text = "Tier 2: Rapid Fire's bullets do 1 damage.";
            Tier2TooltipCost.text = "Cost: $" + gameObject.transform.parent.GetChild(8).GetComponent<ShopUpgradeButton>().tier2Cost;
            Tier3TooltipDesc.text = "Tier 3: Rapid Fire's bullets do 1.5 damage.";
            Tier3TooltipCost.text = "Cost: $" + gameObject.transform.parent.GetChild(8).GetComponent<ShopUpgradeButton>().tier3Cost;
            Tier4TooltipDesc.text = "Tier 4: Rapid Fire's bullets do 2 damage.";
            Tier4TooltipCost.text = "Cost: $" + gameObject.transform.parent.GetChild(8).GetComponent<ShopUpgradeButton>().tier4Cost;

            if (DataHolder.RapidFireTier == 0)
            {
                Tier1TooltipDesc.color = Color.white;
                Tier1TooltipCost.color = Color.white;
                Tier2TooltipDesc.color = Color.white;
                Tier2TooltipCost.color = Color.white;
                Tier3TooltipDesc.color = Color.white;
                Tier3TooltipCost.color = Color.white;
                Tier4TooltipDesc.color = Color.white;
                Tier4TooltipCost.color = Color.white;
            }

            if (DataHolder.RapidFireTier == 1)
            {
                Tier1TooltipDesc.color = Color.green;
                Tier1TooltipCost.color = Color.green;
                Tier2TooltipDesc.color = Color.white;
                Tier2TooltipCost.color = Color.white;
                Tier3TooltipDesc.color = Color.white;
                Tier3TooltipCost.color = Color.white;
                Tier4TooltipDesc.color = Color.white;
                Tier4TooltipCost.color = Color.white;
            }

            if (DataHolder.RapidFireTier == 2)
            {
                Tier1TooltipDesc.color = Color.green;
                Tier1TooltipCost.color = Color.green;
                Tier2TooltipDesc.color = Color.green;
                Tier2TooltipCost.color = Color.green;
                Tier3TooltipDesc.color = Color.white;
                Tier3TooltipCost.color = Color.white;
                Tier4TooltipDesc.color = Color.white;
                Tier4TooltipCost.color = Color.white;
            }

            if (DataHolder.RapidFireTier == 3)
            {
                Tier1TooltipDesc.color = Color.green;
                Tier1TooltipCost.color = Color.green;
                Tier2TooltipDesc.color = Color.green;
                Tier2TooltipCost.color = Color.green;
                Tier3TooltipDesc.color = Color.green;
                Tier3TooltipCost.color = Color.green;
                Tier4TooltipDesc.color = Color.white;
                Tier4TooltipCost.color = Color.white;
            }

            if (DataHolder.RapidFireTier == 4)
            {
                Tier1TooltipDesc.color = Color.green;
                Tier1TooltipCost.color = Color.green;
                Tier2TooltipDesc.color = Color.green;
                Tier2TooltipCost.color = Color.green;
                Tier3TooltipDesc.color = Color.green;
                Tier3TooltipCost.color = Color.green;
                Tier4TooltipDesc.color = Color.green;
                Tier4TooltipCost.color = Color.green;
            }
        }

        if (typeOfUpgrade == "Shield")
        {
            Tier1TooltipDesc.text = "Tier 1: Cast time decreased by 15%";
            Tier1TooltipCost.text = "Cost: $" + gameObject.transform.parent.GetChild(9).GetComponent<ShopUpgradeButton>().tier1Cost;
            Tier2TooltipDesc.text = "Tier 2: Cast time decreased by 30%";
            Tier2TooltipCost.text = "Cost: $" + gameObject.transform.parent.GetChild(9).GetComponent<ShopUpgradeButton>().tier2Cost;
            Tier3TooltipDesc.text = "Tier 3: Cast time decreased by 45%";
            Tier3TooltipCost.text = "Cost: $" + gameObject.transform.parent.GetChild(9).GetComponent<ShopUpgradeButton>().tier3Cost;
            Tier4TooltipDesc.text = "Tier 4: Cast time decreased by 60%";
            Tier4TooltipCost.text = "Cost: $" + gameObject.transform.parent.GetChild(9).GetComponent<ShopUpgradeButton>().tier4Cost;

            if (DataHolder.ShieldTier == 0)
            {
                Tier1TooltipDesc.color = Color.white;
                Tier1TooltipCost.color = Color.white;
                Tier2TooltipDesc.color = Color.white;
                Tier2TooltipCost.color = Color.white;
                Tier3TooltipDesc.color = Color.white;
                Tier3TooltipCost.color = Color.white;
                Tier4TooltipDesc.color = Color.white;
                Tier4TooltipCost.color = Color.white;
            }

            if (DataHolder.ShieldTier == 1)
            {
                Tier1TooltipDesc.color = Color.green;
                Tier1TooltipCost.color = Color.green;
                Tier2TooltipDesc.color = Color.white;
                Tier2TooltipCost.color = Color.white;
                Tier3TooltipDesc.color = Color.white;
                Tier3TooltipCost.color = Color.white;
                Tier4TooltipDesc.color = Color.white;
                Tier4TooltipCost.color = Color.white;
            }

            if (DataHolder.ShieldTier == 2)
            {
                Tier1TooltipDesc.color = Color.green;
                Tier1TooltipCost.color = Color.green;
                Tier2TooltipDesc.color = Color.green;
                Tier2TooltipCost.color = Color.green;
                Tier3TooltipDesc.color = Color.white;
                Tier3TooltipCost.color = Color.white;
                Tier4TooltipDesc.color = Color.white;
                Tier4TooltipCost.color = Color.white;
            }

            if (DataHolder.ShieldTier == 3)
            {
                Tier1TooltipDesc.color = Color.green;
                Tier1TooltipCost.color = Color.green;
                Tier2TooltipDesc.color = Color.green;
                Tier2TooltipCost.color = Color.green;
                Tier3TooltipDesc.color = Color.green;
                Tier3TooltipCost.color = Color.green;
                Tier4TooltipDesc.color = Color.white;
                Tier4TooltipCost.color = Color.white;
            }

            if (DataHolder.ShieldTier == 4)
            {
                Tier1TooltipDesc.color = Color.green;
                Tier1TooltipCost.color = Color.green;
                Tier2TooltipDesc.color = Color.green;
                Tier2TooltipCost.color = Color.green;
                Tier3TooltipDesc.color = Color.green;
                Tier3TooltipCost.color = Color.green;
                Tier4TooltipDesc.color = Color.green;
                Tier4TooltipCost.color = Color.green;
            }
        }

        if (typeOfUpgrade == "Speed")
        {
            Tier1TooltipDesc.text = "Tier 1: Move 10% faster for 5 seconds.";
            Tier1TooltipCost.text = "Cost: $" + gameObject.transform.parent.GetChild(10).GetComponent<ShopUpgradeButton>().tier1Cost;
            Tier2TooltipDesc.text = "Tier 2: Move 20% faster for 5 seconds.";
            Tier2TooltipCost.text = "Cost: $" + gameObject.transform.parent.GetChild(10).GetComponent<ShopUpgradeButton>().tier2Cost;
            Tier3TooltipDesc.text = "Tier 3: Move 30% faster for 5 seconds.";
            Tier3TooltipCost.text = "Cost: $" + gameObject.transform.parent.GetChild(10).GetComponent<ShopUpgradeButton>().tier3Cost;
            Tier4TooltipDesc.text = "Tier 4: Move 40% faster for 5 seconds.";
            Tier4TooltipCost.text = "Cost: $" + gameObject.transform.parent.GetChild(10).GetComponent<ShopUpgradeButton>().tier4Cost;

            if (DataHolder.SpeedTier == 0)
            {
                Tier1TooltipDesc.color = Color.white;
                Tier1TooltipCost.color = Color.white;
                Tier2TooltipDesc.color = Color.white;
                Tier2TooltipCost.color = Color.white;
                Tier3TooltipDesc.color = Color.white;
                Tier3TooltipCost.color = Color.white;
                Tier4TooltipDesc.color = Color.white;
                Tier4TooltipCost.color = Color.white;
            }

            if (DataHolder.SpeedTier == 1)
            {
                Tier1TooltipDesc.color = Color.green;
                Tier1TooltipCost.color = Color.green;
                Tier2TooltipDesc.color = Color.white;
                Tier2TooltipCost.color = Color.white;
                Tier3TooltipDesc.color = Color.white;
                Tier3TooltipCost.color = Color.white;
                Tier4TooltipDesc.color = Color.white;
                Tier4TooltipCost.color = Color.white;
            }

            if (DataHolder.SpeedTier == 2)
            {
                Tier1TooltipDesc.color = Color.green;
                Tier1TooltipCost.color = Color.green;
                Tier2TooltipDesc.color = Color.green;
                Tier2TooltipCost.color = Color.green;
                Tier3TooltipDesc.color = Color.white;
                Tier3TooltipCost.color = Color.white;
                Tier4TooltipDesc.color = Color.white;
                Tier4TooltipCost.color = Color.white;
            }

            if (DataHolder.SpeedTier == 3)
            {
                Tier1TooltipDesc.color = Color.green;
                Tier1TooltipCost.color = Color.green;
                Tier2TooltipDesc.color = Color.green;
                Tier2TooltipCost.color = Color.green;
                Tier3TooltipDesc.color = Color.green;
                Tier3TooltipCost.color = Color.green;
                Tier4TooltipDesc.color = Color.white;
                Tier4TooltipCost.color = Color.white;
            }

            if (DataHolder.SpeedTier == 4)
            {
                Tier1TooltipDesc.color = Color.green;
                Tier1TooltipCost.color = Color.green;
                Tier2TooltipDesc.color = Color.green;
                Tier2TooltipCost.color = Color.green;
                Tier3TooltipDesc.color = Color.green;
                Tier3TooltipCost.color = Color.green;
                Tier4TooltipDesc.color = Color.green;
                Tier4TooltipCost.color = Color.green;
            }
        }

        if (typeOfUpgrade == "Heal")
        {
            Tier1TooltipDesc.text = "Tier 1: Heals the player for 1 HP";
            Tier1TooltipCost.text = "Cost: $" + gameObject.transform.parent.GetChild(11).GetComponent<ShopUpgradeButton>().tier1Cost;
            Tier2TooltipDesc.text = "Tier 2: Heals the player for 2 HP";
            Tier2TooltipCost.text = "Cost: $" + gameObject.transform.parent.GetChild(11).GetComponent<ShopUpgradeButton>().tier2Cost;
            Tier3TooltipDesc.text = "Tier 3: Heals the player for 3 HP";
            Tier3TooltipCost.text = "Cost: $" + gameObject.transform.parent.GetChild(11).GetComponent<ShopUpgradeButton>().tier3Cost;
            Tier4TooltipDesc.text = "Tier 4: Heals the player for 4 HP";
            Tier4TooltipCost.text = "Cost: $" + gameObject.transform.parent.GetChild(11).GetComponent<ShopUpgradeButton>().tier4Cost;

            if (DataHolder.PetHealTier == 0)
            {
                Tier1TooltipDesc.color = Color.white;
                Tier1TooltipCost.color = Color.white;
                Tier2TooltipDesc.color = Color.white;
                Tier2TooltipCost.color = Color.white;
                Tier3TooltipDesc.color = Color.white;
                Tier3TooltipCost.color = Color.white;
                Tier4TooltipDesc.color = Color.white;
                Tier4TooltipCost.color = Color.white;
            }

            if (DataHolder.PetHealTier == 1)
            {
                Tier1TooltipDesc.color = Color.green;
                Tier1TooltipCost.color = Color.green;
                Tier2TooltipDesc.color = Color.white;
                Tier2TooltipCost.color = Color.white;
                Tier3TooltipDesc.color = Color.white;
                Tier3TooltipCost.color = Color.white;
                Tier4TooltipDesc.color = Color.white;
                Tier4TooltipCost.color = Color.white;
            }

            if (DataHolder.PetHealTier == 2)
            {
                Tier1TooltipDesc.color = Color.green;
                Tier1TooltipCost.color = Color.green;
                Tier2TooltipDesc.color = Color.green;
                Tier2TooltipCost.color = Color.green;
                Tier3TooltipDesc.color = Color.white;
                Tier3TooltipCost.color = Color.white;
                Tier4TooltipDesc.color = Color.white;
                Tier4TooltipCost.color = Color.white;
            }

            if (DataHolder.PetHealTier == 3)
            {
                Tier1TooltipDesc.color = Color.green;
                Tier1TooltipCost.color = Color.green;
                Tier2TooltipDesc.color = Color.green;
                Tier2TooltipCost.color = Color.green;
                Tier3TooltipDesc.color = Color.green;
                Tier3TooltipCost.color = Color.green;
                Tier4TooltipDesc.color = Color.white;
                Tier4TooltipCost.color = Color.white;
            }

            if (DataHolder.PetHealTier == 4)
            {
                Tier1TooltipDesc.color = Color.green;
                Tier1TooltipCost.color = Color.green;
                Tier2TooltipDesc.color = Color.green;
                Tier2TooltipCost.color = Color.green;
                Tier3TooltipDesc.color = Color.green;
                Tier3TooltipCost.color = Color.green;
                Tier4TooltipDesc.color = Color.green;
                Tier4TooltipCost.color = Color.green;
            }
        }

        if (typeOfUpgrade == "Damage")
        {
            Tier1TooltipDesc.text = "Tier 1: Pet does 125% damage.";
            Tier1TooltipCost.text = "Cost: $" + gameObject.transform.parent.GetChild(12).GetComponent<ShopUpgradeButton>().tier1Cost;
            Tier2TooltipDesc.text = "Tier 2: Pet does 150% damage.";
            Tier2TooltipCost.text = "Cost: $" + gameObject.transform.parent.GetChild(12).GetComponent<ShopUpgradeButton>().tier2Cost;
            Tier3TooltipDesc.text = "Tier 3: Pet does 175% damage.";
            Tier3TooltipCost.text = "Cost: $" + gameObject.transform.parent.GetChild(12).GetComponent<ShopUpgradeButton>().tier3Cost;
            Tier4TooltipDesc.text = "Tier 4: Pet does 200% damage.";
            Tier4TooltipCost.text = "Cost: $" + gameObject.transform.parent.GetChild(12).GetComponent<ShopUpgradeButton>().tier4Cost;

            if (DataHolder.PetDamageTier == 0)
            {
                Tier1TooltipDesc.color = Color.white;
                Tier1TooltipCost.color = Color.white;
                Tier2TooltipDesc.color = Color.white;
                Tier2TooltipCost.color = Color.white;
                Tier3TooltipDesc.color = Color.white;
                Tier3TooltipCost.color = Color.white;
                Tier4TooltipDesc.color = Color.white;
                Tier4TooltipCost.color = Color.white;
            }

            if (DataHolder.PetDamageTier == 1)
            {
                Tier1TooltipDesc.color = Color.green;
                Tier1TooltipCost.color = Color.green;
                Tier2TooltipDesc.color = Color.white;
                Tier2TooltipCost.color = Color.white;
                Tier3TooltipDesc.color = Color.white;
                Tier3TooltipCost.color = Color.white;
                Tier4TooltipDesc.color = Color.white;
                Tier4TooltipCost.color = Color.white;
            }

            if (DataHolder.PetDamageTier == 2)
            {
                Tier1TooltipDesc.color = Color.green;
                Tier1TooltipCost.color = Color.green;
                Tier2TooltipDesc.color = Color.green;
                Tier2TooltipCost.color = Color.green;
                Tier3TooltipDesc.color = Color.white;
                Tier3TooltipCost.color = Color.white;
                Tier4TooltipDesc.color = Color.white;
                Tier4TooltipCost.color = Color.white;
            }

            if (DataHolder.PetDamageTier == 3)
            {
                Tier1TooltipDesc.color = Color.green;
                Tier1TooltipCost.color = Color.green;
                Tier2TooltipDesc.color = Color.green;
                Tier2TooltipCost.color = Color.green;
                Tier3TooltipDesc.color = Color.green;
                Tier3TooltipCost.color = Color.green;
                Tier4TooltipDesc.color = Color.white;
                Tier4TooltipCost.color = Color.white;
            }

            if (DataHolder.PetDamageTier == 4)
            {
                Tier1TooltipDesc.color = Color.green;
                Tier1TooltipCost.color = Color.green;
                Tier2TooltipDesc.color = Color.green;
                Tier2TooltipCost.color = Color.green;
                Tier3TooltipDesc.color = Color.green;
                Tier3TooltipCost.color = Color.green;
                Tier4TooltipDesc.color = Color.green;
                Tier4TooltipCost.color = Color.green;
            }
        }

        if (typeOfUpgrade == "PetSpeed")
        {
            Tier1TooltipDesc.text = "Tier 1: Pet moves 15% faster.";
            Tier1TooltipCost.text = "Cost: $" + gameObject.transform.parent.GetChild(13).GetComponent<ShopUpgradeButton>().tier1Cost;
            Tier2TooltipDesc.text = "Tier 2: Pet moves 20% faster.";
            Tier2TooltipCost.text = "Cost: $" + gameObject.transform.parent.GetChild(13).GetComponent<ShopUpgradeButton>().tier2Cost;
            Tier3TooltipDesc.text = "Tier 3: Pet moves 25% faster.";
            Tier3TooltipCost.text = "Cost: $" + gameObject.transform.parent.GetChild(13).GetComponent<ShopUpgradeButton>().tier3Cost;
            Tier4TooltipDesc.text = "Tier 4: Pet moves 30% faster.";
            Tier4TooltipCost.text = "Cost: $" + gameObject.transform.parent.GetChild(13).GetComponent<ShopUpgradeButton>().tier4Cost;

            if (DataHolder.PetSpeedTier == 0)
            {
                Tier1TooltipDesc.color = Color.white;
                Tier1TooltipCost.color = Color.white;
                Tier2TooltipDesc.color = Color.white;
                Tier2TooltipCost.color = Color.white;
                Tier3TooltipDesc.color = Color.white;
                Tier3TooltipCost.color = Color.white;
                Tier4TooltipDesc.color = Color.white;
                Tier4TooltipCost.color = Color.white;
            }

            if (DataHolder.PetSpeedTier == 1)
            {
                Tier1TooltipDesc.color = Color.green;
                Tier1TooltipCost.color = Color.green;
                Tier2TooltipDesc.color = Color.white;
                Tier2TooltipCost.color = Color.white;
                Tier3TooltipDesc.color = Color.white;
                Tier3TooltipCost.color = Color.white;
                Tier4TooltipDesc.color = Color.white;
                Tier4TooltipCost.color = Color.white;
            }

            if (DataHolder.PetSpeedTier == 2)
            {
                Tier1TooltipDesc.color = Color.green;
                Tier1TooltipCost.color = Color.green;
                Tier2TooltipDesc.color = Color.green;
                Tier2TooltipCost.color = Color.green;
                Tier3TooltipDesc.color = Color.white;
                Tier3TooltipCost.color = Color.white;
                Tier4TooltipDesc.color = Color.white;
                Tier4TooltipCost.color = Color.white;
            }

            if (DataHolder.PetSpeedTier == 3)
            {
                Tier1TooltipDesc.color = Color.green;
                Tier1TooltipCost.color = Color.green;
                Tier2TooltipDesc.color = Color.green;
                Tier2TooltipCost.color = Color.green;
                Tier3TooltipDesc.color = Color.green;
                Tier3TooltipCost.color = Color.green;
                Tier4TooltipDesc.color = Color.white;
                Tier4TooltipCost.color = Color.white;
            }

            if (DataHolder.PetSpeedTier == 4)
            {
                Tier1TooltipDesc.color = Color.green;
                Tier1TooltipCost.color = Color.green;
                Tier2TooltipDesc.color = Color.green;
                Tier2TooltipCost.color = Color.green;
                Tier3TooltipDesc.color = Color.green;
                Tier3TooltipCost.color = Color.green;
                Tier4TooltipDesc.color = Color.green;
                Tier4TooltipCost.color = Color.green;
            }
        }

        if (typeOfUpgrade == "Max Health")
        {
            Tier1TooltipDesc.text = "Tier 1: Pet has 10 max HP";
            Tier1TooltipCost.text = "Cost: $" + gameObject.transform.parent.GetChild(14).GetComponent<ShopUpgradeButton>().tier1Cost;
            Tier2TooltipDesc.text = "Tier 2: Pet has 15 max HP";
            Tier2TooltipCost.text = "Cost: $" + gameObject.transform.parent.GetChild(14).GetComponent<ShopUpgradeButton>().tier2Cost;
            Tier3TooltipDesc.text = "Tier 3: Pet has 20 max HP";
            Tier3TooltipCost.text = "Cost: $" + gameObject.transform.parent.GetChild(14).GetComponent<ShopUpgradeButton>().tier3Cost;
            Tier4TooltipDesc.text = "Tier 4: Pet has 25 max HP";
            Tier4TooltipCost.text = "Cost: $" + gameObject.transform.parent.GetChild(14).GetComponent<ShopUpgradeButton>().tier4Cost;

            if (DataHolder.PetMaxHealthTier == 0)
            {
                Tier1TooltipDesc.color = Color.white;
                Tier1TooltipCost.color = Color.white;
                Tier2TooltipDesc.color = Color.white;
                Tier2TooltipCost.color = Color.white;
                Tier3TooltipDesc.color = Color.white;
                Tier3TooltipCost.color = Color.white;
                Tier4TooltipDesc.color = Color.white;
                Tier4TooltipCost.color = Color.white;
            }

            if (DataHolder.PetMaxHealthTier == 1)
            {
                Tier1TooltipDesc.color = Color.green;
                Tier1TooltipCost.color = Color.green;
                Tier2TooltipDesc.color = Color.white;
                Tier2TooltipCost.color = Color.white;
                Tier3TooltipDesc.color = Color.white;
                Tier3TooltipCost.color = Color.white;
                Tier4TooltipDesc.color = Color.white;
                Tier4TooltipCost.color = Color.white;
            }

            if (DataHolder.PetMaxHealthTier == 2)
            {
                Tier1TooltipDesc.color = Color.green;
                Tier1TooltipCost.color = Color.green;
                Tier2TooltipDesc.color = Color.green;
                Tier2TooltipCost.color = Color.green;
                Tier3TooltipDesc.color = Color.white;
                Tier3TooltipCost.color = Color.white;
                Tier4TooltipDesc.color = Color.white;
                Tier4TooltipCost.color = Color.white;
            }

            if (DataHolder.PetMaxHealthTier == 3)
            {
                Tier1TooltipDesc.color = Color.green;
                Tier1TooltipCost.color = Color.green;
                Tier2TooltipDesc.color = Color.green;
                Tier2TooltipCost.color = Color.green;
                Tier3TooltipDesc.color = Color.green;
                Tier3TooltipCost.color = Color.green;
                Tier4TooltipDesc.color = Color.white;
                Tier4TooltipCost.color = Color.white;
            }

            if (DataHolder.PetMaxHealthTier == 4)
            {
                Tier1TooltipDesc.color = Color.green;
                Tier1TooltipCost.color = Color.green;
                Tier2TooltipDesc.color = Color.green;
                Tier2TooltipCost.color = Color.green;
                Tier3TooltipDesc.color = Color.green;
                Tier3TooltipCost.color = Color.green;
                Tier4TooltipDesc.color = Color.green;
                Tier4TooltipCost.color = Color.green;
            }
        }
    }
}
