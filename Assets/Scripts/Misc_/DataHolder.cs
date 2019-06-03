using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataHolder
{
    static int coins;
    static int totalCoins;
    static int spendCoins;
    static int pendingCoins;
    static int armorTier;
    static int speedTier;
    static int hpFillTier;
    static int rifleTier;
    static int shotgunTier;
    static int grenadeTier;
    static int rapidFireTier;
    static int shieldTier;
    static int petHealTier;
    static int petDamageTier;
    static int petSpeedTier;
    static int petMaxHealthTier;

    static int armorPoints;
    static int healthToRestore;
    static float movementSpeedIncrease;
    static int abilityGrenadeDamage;
    static int rifleBulletDamage;
    static int shotgunBulletDamage;
    static float rapidFireBulletDamage;
    static int petHeal;
    static int explosionBean;
    static int iceBean;
    static int greasyBean;
    static int kultists;
    static int kultistsAtNight;

    static string leftMouseItem;
    static string rightMouseItem;
    static string qItem;
    static string eItem;
    static string rItem;
    static string tItem;

    public static int Coins
    {
        get
        {
            return coins;
        }
        set
        {
            coins = value;
        }
    }

    public static int TotalCoins
    {
        get
        {
            return totalCoins;
        }
        set
        {
            totalCoins = value;
        }
    }

    public static int SpendCoins
    {
        get
        {
            return spendCoins;
        }
        set
        {
            spendCoins = value;
        }
    }

    public static int PendingCoins
    {
        get
        {
            return pendingCoins;
        }

        set
        {
            pendingCoins = value;
        }
    }

    public static int ArmorTier
    {
        get
        {
            return armorTier;
        }
        set
        {
            armorTier = value;
        }
    }

    public static int SpeedTier
    {
        get
        {
            return speedTier;
        }
        set
        {
            speedTier = value;
        }
    }

    public static int HPFillTier
    {
        get
        {
            return hpFillTier;
        }
        set
        {
            hpFillTier = value;
        }
    }

    public static int RifleTier
    {
        get
        {
            return rifleTier;
        }
        set
        {
            rifleTier = value;
        }
    }

    public static int ShotgunTier
    {
        get
        {
            return shotgunTier;
        }
        set
        {
            shotgunTier = value;
        }
    }

    public static int GrenadeTier
    {
        get
        {
            return grenadeTier;
        }
        set
        {
            grenadeTier = value;
        }
    }

    public static int RapidFireTier
    {
        get
        {
            return rapidFireTier;
        }
        set
        {
            rapidFireTier = value;
        }
    }

    public static int ShieldTier
    {
        get
        {
            return shieldTier;
        }
        set
        {
            shieldTier = value;
        }
    }

    public static int PetHealTier
    {
        get
        {
            return petHealTier;
        }
        set
        {
            petHealTier = value;
        }
    }

    public static int PetDamageTier
    {
        get
        {
            return petDamageTier;
        }
        set
        {
            petDamageTier = value;
        }
    }

    public static int PetSpeedTier
    {
        get
        {
            return petSpeedTier;
        }
        set
        {
            petSpeedTier = value;
        }
    }

    public static int PetMaxHealthTier
    {
        get
        {
            return petMaxHealthTier;
        }
        set
        {
            petMaxHealthTier = value;
        }
    }

    public static int ArmorPoints
    {
        get
        {
            return armorPoints;
        }
        set
        {
            armorPoints = value;
        }
    }

    public static int HealthToRestore
    {
        get
        {
            return healthToRestore;
        }
        set
        {
            healthToRestore = value;
        }
    }

    public static float MovementSpeedIncrease
    {
        get
        {
            return movementSpeedIncrease;
        }
        set
        {
            movementSpeedIncrease = value;
        }
    }

    public static int GrenadeDamage
    {
        get
        {
            return abilityGrenadeDamage;
        }
        set
        {
            abilityGrenadeDamage = value;
        }
    }

    public static int RifleBulletDamage
    {
        get
        {
            return rifleBulletDamage;
        }
        set
        {
            rifleBulletDamage = value;
        }
    }

    public static int ShotgunBulletDamage
    {
        get
        {
            return shotgunBulletDamage;
        }
        set
        {
            shotgunBulletDamage = value;
        }
    }

    public static float RapidFireBulletDamage
    {
        get
        {
            return rapidFireBulletDamage;
        }
        set
        {
            rapidFireBulletDamage = value;
        }
    }

    public static int PetHeal
    {
        get
        {
            return petHeal;
        }
        set
        {
            petHeal = value;
        }
    }

    public static int IceBean
    {
        get
        {
            return iceBean;
        }
        set
        {
            iceBean = value;
        }
    }

    public static int ExplosionBean
    {
        get
        {
            return explosionBean;
        }
        set
        {
            explosionBean = value;
        }
    }

    public static int GreasyBean
    {
        get
        {
            return greasyBean;
        }
        set
        {
            greasyBean = value;
        }
    }

    public static int Kultists
    {
        get
        {
            return kultists;
        }
        set
        {
            kultists = value;
        }
    }

    public static int KultistsAtNight
    {
        get
        {
            return kultistsAtNight;
        }
        set
        {
            kultistsAtNight = value;
        }
    }

    public static string LeftMouseWeapon
    {
        get
        {
            return leftMouseItem;
        }
        set
        {
            leftMouseItem = value;
        }
    }

    public static string RightMouseWeapon
    {
        get
        {
            return rightMouseItem;
        }
        set
        {
            rightMouseItem = value;
        }
    }

    public static string QAbility
    {
        get
        {
            return qItem;
        }
        set
        {
            qItem = value;
        }
    }

    public static string EAbility
    {
        get
        {
            return eItem;
        }
        set
        {
            eItem = value;
        }
    }

    public static string RAbility
    {
        get
        {
            return rItem;
        }
        set
        {
            rItem = value;
        }
    }

    public static string TAbility
    {
        get
        {
            return tItem;
        }
        set
        {
            tItem = value;
        }
    }
}