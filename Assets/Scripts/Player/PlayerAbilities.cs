using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    private PlayerHealthManager phm;
    private Player player;
    private AudioSource[] ad;
    [HideInInspector] public AudioSource aud;
    [HideInInspector] public AudioSource aud2;
    public AudioClip rifleSound;
    public AudioClip rapidFireSound;
    public AudioClip shotgunSound;
    public AudioClip grenadeSound;
    public AudioClip shieldSound;
    public AudioClip meleeSound;
    public AudioClip armorSound;
    public AudioClip hpFillSound;
    public AudioClip speedSound;
    private bool iceEnchanted;
    private bool explosionEnchanted;


    private void Start()
    {
        ad = gameObject.GetComponentsInChildren<AudioSource>();
        aud = ad[0];
        aud2 = ad[1];
        player = gameObject.GetComponent<Player>();
        phm = gameObject.GetComponent<PlayerHealthManager>();
    }

    /*public void Armor ()
    {
        aud.clip = armorSound;
        phm.armor = DataHolder.ArmorPoints;
        aud.Play();
    }*/

    public void HPFill()
    {
        aud.clip = hpFillSound;
        phm.currentHealth += DataHolder.HealthToRestore;
        aud.Play();
    }

    public void Rifle ()
    {
        aud.clip = rifleSound;
        GameObject bb = Instantiate(player.bullet, player.bulletSpawn.transform.position, Quaternion.identity);
        bb.GetComponent<Rigidbody2D>().AddForce((player.mousePos - transform.position) * player.bulletSpeed);
        bb.GetComponent<Bullet>().damage = DataHolder.RifleBulletDamage;
        if(explosionEnchanted)
        {
            bb.GetComponent<Bullet>().explosionB = true;
            bb.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        if(iceEnchanted)
        {
            bb.GetComponent<Bullet>().ice = true;
            bb.GetComponent<SpriteRenderer>().color = Color.blue;
        }
        else
        {
            bb.GetComponent<SpriteRenderer>().color = Color.white;
        }
        aud.Play();
    }

    public void Shotgun ()
    {
        aud.clip = shotgunSound;
        Vector3 targetDelta = player.mousePos - transform.position;
        Vector3 force = targetDelta.normalized * player.bulletSpeed;
        Vector3 eulerAngles = new Vector3 (0, 0, 0);
        GameObject bb = Instantiate(player.bullet, player.bulletSpawn.transform.position, Quaternion.identity);
        bb.GetComponent<Rigidbody2D>().AddForce(targetDelta * player.bulletSpeed);
        bb.GetComponent<Bullet>().damage = DataHolder.ShotgunBulletDamage;
        if (explosionEnchanted)
        {
            bb.GetComponent<Bullet>().explosionB = true;
            bb.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        if (iceEnchanted)
        {
            bb.GetComponent<Bullet>().ice = true;
            bb.GetComponent<SpriteRenderer>().color = Color.blue;
        }
        else
        {
            bb.GetComponent<SpriteRenderer>().color = Color.white;
        }
        eulerAngles.z = -15;
        Vector3 bb2Force = Quaternion.Euler(eulerAngles) * force;
        GameObject bb2 = Instantiate(player.bullet, player.bulletSpawn.transform.position, Quaternion.identity);
        bb2.GetComponent<Rigidbody2D>().AddForce(bb2Force * (player.bulletSpeed/6));
        bb2.GetComponent<Bullet>().damage = DataHolder.ShotgunBulletDamage;
        if (explosionEnchanted)
        {
            bb2.GetComponent<Bullet>().explosionB = true;
            bb2.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        if (iceEnchanted)
        {
            bb2.GetComponent<Bullet>().ice = true;
            bb2.GetComponent<SpriteRenderer>().color = Color.blue;
        }
        else
        {
            bb2.GetComponent<SpriteRenderer>().color = Color.white;
        }
        eulerAngles.z = 15;
        Vector3 bb3Force = Quaternion.Euler(eulerAngles) * force;
        GameObject bb3 = Instantiate(player.bullet, player.bulletSpawn.transform.position, Quaternion.identity);
        bb3.GetComponent<Rigidbody2D>().AddForce(bb3Force * (player.bulletSpeed/6));
        bb3.GetComponent<Bullet>().damage = DataHolder.ShotgunBulletDamage;
        if (explosionEnchanted)
        {
            bb3.GetComponent<Bullet>().explosionB = true;
            bb3.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        if (iceEnchanted)
        {
            bb3.GetComponent<Bullet>().ice = true;
            bb3.GetComponent<SpriteRenderer>().color = Color.blue;
        }
        else
        {
            bb3.GetComponent<SpriteRenderer>().color = Color.white;
        }
        aud.Play();
    }

    public void Grenade ()
    {
        aud.clip = grenadeSound;
        //Need to come back and make this work
        GameObject grenade = Instantiate(player.grenade, player.bulletSpawn.transform.position, Quaternion.identity);
        grenade.GetComponent<Rigidbody2D>().AddForce((player.mousePos - transform.position) * player.grenadeThrowForce);
        grenade.GetComponent<Grenade>().grenadeDamage = DataHolder.GrenadeDamage;
        aud.Play();
    }

    public void RapidFire ()
    {
        aud.clip = rapidFireSound;
        GameObject bb = Instantiate(player.bullet, player.bulletSpawn.transform.position, Quaternion.identity);
        bb.GetComponent<Rigidbody2D>().AddForce((player.mousePos - transform.position) * player.bulletSpeed);
        bb.GetComponent<Bullet>().damage = DataHolder.RapidFireBulletDamage;
        if (explosionEnchanted)
        {
            bb.GetComponent<Bullet>().explosionB = true;
            bb.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        if (iceEnchanted)
        {
            bb.GetComponent<Bullet>().ice = true;
            bb.GetComponent<SpriteRenderer>().color = Color.blue;
        }
        else
        {
            bb.GetComponent<SpriteRenderer>().color = Color.white;
        }

        aud.Play();
    }

    public void Shield ()
    {
        aud.clip = shieldSound;
        if (!player.isShieldingAlready)
        {
            player.anim.SetBool("IsShielding", true);
            player.isShieldingAlready = true;
        }

        else if (player.isShieldingAlready)
        {
            player.anim.SetBool("IsShielding", false);
            player.isShieldingAlready = false;
        }
        aud.Play();

    }

    public void Speed ()
    {
        aud.clip = speedSound;
        player.moveSpeed += DataHolder.MovementSpeedIncrease;
        aud.Play();
    }

    public void ElementalBeans (string whatBeanToUse)
    {
        if(whatBeanToUse == "Ice")
        {
            if(DataHolder.IceBean >= 1)
            {
                iceEnchanted = true;
                DataHolder.IceBean -= 1;
            }
        }

        if(whatBeanToUse == "Explosion")
        {
            if(DataHolder.ExplosionBean >= 1)
            {
                explosionEnchanted = true;
                DataHolder.ExplosionBean -= 1;
            }
        }

        if(whatBeanToUse == "Greasy")
        {
            if(DataHolder.GreasyBean >= 1)
            {
                gameObject.GetComponent<Player>().shotDelay /= 2;
                gameObject.GetComponent<Player>().shotDelay2 /= 2;
                DataHolder.GreasyBean -= 1;
            }
        }
    }
}
