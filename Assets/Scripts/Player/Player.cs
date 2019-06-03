using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [HideInInspector] public bool canMove;
    public Animator anim;
    public float moveSpeed;
    private float defaultMoveSpeed;
    public float slowDuration;
    private float slowTimer;
    public GameObject grenade;
    public float grenadeThrowForce;
    public GameObject bullet;
    public GameObject bulletSpawn;
    public float bulletSpeed;
    public float stamina;
    public bool hasEnoughStamina;
    public float rapidFireDelay;
    public float rifleDelay;
    public float shotgunDelay;
    public int ammo;
    public float shotDelay;
    public float shotDelay2;
    public bool shot;
    private bool shot2;
    //[HideInInspector] public Vector2 lookDirection;
    [HideInInspector] public Vector3 mousePos;
    private float sprintSpeed;
    public float shotTimer;
    private float shotTimer2;
    public float greasyDuration;
    private float greasyTimer;
    public string currentBeanEquipped;
    public string[] beanTypes;
    private int beanNumber;
    private PlayerAbilities pa;
    [HideInInspector] public bool isShieldingAlready = false;
    private float defaultTimer;
    private float defaultTimer2;
    private float defaultDelay;
    private float defaultDelay2;
    private AudioSource ad;

    private bool rapidFireEquipped;
    private bool rifleEquipped;
    private bool shieldEquipped;
    private bool shotgunEquipped;
    private bool meleeEquipped;
    private bool grenadeEquipped;
    private bool armorEquipped;
    private bool speedEquipped;
    private bool hpfillEquipped;
    private bool r_rapidFireEquipped;
    private bool r_rifleEquipped;
    private bool r_shieldEquipped;
    private bool r_shotgunEquipped;
    private bool r_meleeEquipped;
    private bool r_grenadeEquipped;

    private bool q_armorSelected;
    private bool q_speedSelected;
    private bool q_hpfillSelected;
    private bool e_armorSelected;
    private bool e_speedSelected;
    private bool e_hpfillSelected;
    private bool r_armorSelected;
    private bool r_speedSelected;
    private bool r_hpfillSelected;
    private bool t_armorSelected;
    private bool t_speedSelected;
    private bool t_hpfillSelected;

    public AudioClip reload;

    private void Start()
    {
        ad = gameObject.GetComponentInChildren<AudioSource>();
        moveSpeed = DataHolder.MovementSpeedIncrease;
        defaultMoveSpeed = moveSpeed;
        greasyTimer = greasyDuration;
        pa = gameObject.GetComponent<PlayerAbilities>();
        sprintSpeed = moveSpeed *= 1.5f;
        slowTimer = slowDuration;

        if(DataHolder.LeftMouseWeapon == "Rapid Fire")
        {
            rapidFireEquipped = true;
            shotTimer = rapidFireDelay;
            shotDelay = rapidFireDelay;

        }

        if (DataHolder.LeftMouseWeapon == "Revolver")
        {
            rifleEquipped = true;
            shotTimer = rifleDelay;
            shotDelay = rifleDelay;
        }

        if (DataHolder.LeftMouseWeapon == "Shield")
        {
            shieldEquipped = true;
        }

        if (DataHolder.LeftMouseWeapon == "Grenade")
        {
            grenadeEquipped = true;
        }

        if (DataHolder.LeftMouseWeapon == "Shotgun")
        {
            shotgunEquipped = true;
            shotTimer = shotgunDelay;
            shotDelay = shotgunDelay;
        }

        if (DataHolder.LeftMouseWeapon == "Melee")
        {
            meleeEquipped = true;
        }

        ////////////////////////

        if (DataHolder.RightMouseWeapon == "Rapid Fire")
        {
            r_rapidFireEquipped = true;
            shotTimer2 = rapidFireDelay;
            shotDelay2 = rapidFireDelay;
        }

        if (DataHolder.RightMouseWeapon == "Revolver")
        {
            r_rifleEquipped = true;
            shotTimer2 = rifleDelay;
            shotDelay2 = rifleDelay;
        }

        if (DataHolder.RightMouseWeapon == "Shield")
        {
            r_shieldEquipped = true;
        }

        if (DataHolder.RightMouseWeapon == "Grenade")
        {
            r_grenadeEquipped = true;
        }

        if (DataHolder.RightMouseWeapon == "Shotgun")
        {
            r_shotgunEquipped = true;
            shotTimer2 = shotgunDelay;
            shotDelay2 = shotgunDelay;
        }

        if (DataHolder.RightMouseWeapon == "Melee")
        {
            r_meleeEquipped = true;
        }

        /////////////////////
        
        if(DataHolder.QAbility == "Armor")
        {
            q_armorSelected = true;
        }

        if(DataHolder.QAbility == "Speed")
        {
            q_speedSelected = true;
        }

        if(DataHolder.QAbility == "HP Fill")
        {
            q_hpfillSelected = true;
        }

        ////////////////////

        if (DataHolder.EAbility == "Armor")
        {
            e_armorSelected = true;
        }

        if (DataHolder.EAbility == "Speed")
        {
            e_speedSelected = true;
        }

        if (DataHolder.EAbility == "HP Fill")
        {
            e_hpfillSelected = true;
        }

        ///////////////////

        if (DataHolder.RAbility == "Armor")
        {
            r_armorSelected = true;
        }

        if (DataHolder.RAbility == "Speed")
        {
            r_speedSelected = true;
        }

        if (DataHolder.RAbility == "HP Fill")
        {
            r_hpfillSelected = true;
        }

        //////////////////

        if (DataHolder.TAbility == "Armor")
        {
            t_armorSelected = true;
        }

        if (DataHolder.TAbility == "Speed")
        {
            t_speedSelected = true;
        }

        if (DataHolder.TAbility == "HP Fill")
        {
            t_hpfillSelected = true;
        }

        defaultDelay = shotDelay;
        defaultDelay2 = shotDelay2;
        currentBeanEquipped = beanTypes[0];
    }

    void Update () 
    {
        if(moveSpeed < defaultMoveSpeed)
        {
            slowTimer -= Time.deltaTime;
            if(slowTimer <= 0)
            {
                moveSpeed = defaultMoveSpeed;
                slowTimer = slowDuration;
            }
        }

        if(currentBeanEquipped == beanTypes[0])
        {
            beanNumber = 0;
        }

        if (currentBeanEquipped == beanTypes[1])
        {
            beanNumber = 1;
        }

        if (currentBeanEquipped == beanTypes[2])
        {
            beanNumber = 2;
        }

        if (Time.timeScale == 0f)
        {
            canMove = false;
        }
        else
        {
            canMove = true;
        }

        Debug.Log(canMove);
        
        if(shotDelay < defaultDelay | shotDelay2 < defaultDelay2)
        {
            Debug.Log(greasyTimer);
            greasyTimer -= Time.deltaTime;
            if(greasyTimer <= 0)
            {
                shotDelay = defaultDelay;
                shotDelay2 = defaultDelay2;
                greasyTimer = greasyDuration;
            }
        }

        if(shot)
        {
            shotTimer -= Time.deltaTime;
            if(shotTimer <= 0)
            {
                ad.clip = reload;
                ad.Play();
                shot = false;
                shotTimer = shotDelay;
            }
        }

        if(shot2)
        {
            shotTimer2 -= Time.deltaTime;
            if(shotTimer2 <= 0)
            {
                ad.clip = reload;
                ad.Play();
                shot2 = false;
                shotTimer2 = shotDelay2;
            }
        }

        if(!hasEnoughStamina)
        {
            moveSpeed = 0.1f;
            stamina += Time.deltaTime;
            if (stamina >= 10)
                hasEnoughStamina = true;
        }

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);

        if (canMove)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * moveSpeed, Space.World);
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * moveSpeed, Space.World);
            }

            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.up * moveSpeed, Space.World);
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.down * moveSpeed, Space.World);
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                anim.SetBool("IsMoving", true);
                if(!pa.aud2.isPlaying)
                    pa.aud2.Play();
            }

            if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
            {
                anim.SetBool("IsMoving", false);
                //pa.aud2.Stop();
            }
        }

        if(anim.GetBool("IsShielding") == true)
        {
            canMove = false;
        }

        if(anim.GetBool("IsShielding") == false)
        {
            canMove = true;
        }

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (shot == false)
            {
                if (rifleEquipped)
                    pa.Rifle();

                if (shotgunEquipped)
                    pa.Shotgun();

                if (grenadeEquipped)
                    pa.Grenade();

                if (shieldEquipped)
                    pa.Shield();

                shot = true;
            }
        }

        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (shot2 == false)
            {
                if (r_rifleEquipped)
                    pa.Rifle();

                if (r_shotgunEquipped)
                    pa.Shotgun();

                if (r_grenadeEquipped)
                    pa.Grenade();

                if (r_shieldEquipped)
                    pa.Shield();

                shot2 = true;
            }
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (!shot)
            {
                if (rapidFireEquipped)
                {
                    pa.RapidFire();
                }

                shot = true;
            }
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            if (!shot2)
            {
                if (rapidFireEquipped)
                {
                    pa.RapidFire();
                }

                shot2 = true;
            }
        }

        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            //pa.aud.Stop();
        }

        if(Input.GetKeyUp(KeyCode.Mouse1))
        {
            //pa.aud.Stop();
        }

        if (Input.GetKey(KeyCode.Q))
        {
            if(q_armorSelected)
            {
            //    pa.Armor();
            }

            if(q_hpfillSelected)
            {
                pa.HPFill();
            }

            if(q_speedSelected)
            {
                pa.Speed();
            }
        }

        if(Input.GetKey(KeyCode.E))
        {
            /*if (e_armorSelected)
            {
                pa.Armor();
            }*/

            if (e_hpfillSelected)
            {
                pa.HPFill();
            }

            if (e_speedSelected)
            {
                pa.Speed();
            }
        }

        if (Input.GetKey(KeyCode.R))
        {
            if (r_armorSelected)
            {
            //    pa.Armor();
            }

            if (r_hpfillSelected)
            {
                pa.HPFill();
            }

            if (r_speedSelected)
            {
                pa.Speed();
            }
        }

        if (Input.GetKey(KeyCode.T))
        {
            if (t_armorSelected)
            {
            //    pa.Armor();
            }

            if (t_hpfillSelected)
            {
                pa.HPFill();
            }

            if (t_speedSelected)
            {
                pa.Speed();
            }
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (hasEnoughStamina)
            {
                moveSpeed = sprintSpeed;
                stamina -= Time.deltaTime;
                if (stamina <= 0)
                    hasEnoughStamina = false;
            }
        }

        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = 0.1f;
        }

        if(Input.GetKeyDown(KeyCode.Mouse2))
        {
            pa.ElementalBeans(currentBeanEquipped);
        }

        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if(currentBeanEquipped == beanTypes[0])
            {
                currentBeanEquipped = beanTypes[2];
            }

            else if (currentBeanEquipped != beanTypes[0])
            {
                currentBeanEquipped = beanTypes[beanNumber - 1];
            }
        }

        if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (currentBeanEquipped != beanTypes[2])
            {
                currentBeanEquipped = beanTypes[beanNumber + 1];
            }

            else if (currentBeanEquipped == beanTypes[2])
            {
                currentBeanEquipped = beanTypes[0];
            }
        }
    }
}
