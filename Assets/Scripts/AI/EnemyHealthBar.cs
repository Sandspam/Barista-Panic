using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Material green;
    public Material white;
    public bool showingBar;
    public float howLongToShowBar;
    private float showTimer;
    public Image healthBar;

    private GameObject HPSlot1;
    private GameObject HPSlot2;
    private GameObject HPSlot3;
    private GameObject HPSlot4;
    private GameObject HPSlot5;
    private EnemyHealthManager ehm;

    private void Start()
    {
        HPSlot1 = gameObject.transform.GetChild(0).gameObject;
        HPSlot2 = gameObject.transform.GetChild(1).gameObject;
        HPSlot3 = gameObject.transform.GetChild(2).gameObject;
        HPSlot4 = gameObject.transform.GetChild(3).gameObject;
        HPSlot5 = gameObject.transform.GetChild(4).gameObject;
        ehm = gameObject.transform.parent.GetComponent<EnemyHealthManager>();
        showTimer = howLongToShowBar;
        DontShowBar();
    }

    private void Update()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);

        if (showingBar)
        {
            showTimer -= Time.deltaTime;
            if(showTimer <= 0)
            {
                DontShowBar();
                showTimer = howLongToShowBar;
                showingBar = false;
            }
        }
    }

    public void ShowHealthBar ()
    {
        HPSlot1.SetActive(true);
        HPSlot2.SetActive(true);
        HPSlot3.SetActive(true);
        HPSlot4.SetActive(true);
        HPSlot5.SetActive(true);

        if (ehm.currentHealth == 5)
        {
            HPSlot1.GetComponent<MeshRenderer>().material = green;
            HPSlot2.GetComponent<MeshRenderer>().material = green;
            HPSlot3.GetComponent<MeshRenderer>().material = green;
            HPSlot4.GetComponent<MeshRenderer>().material = green;
            HPSlot5.GetComponent<MeshRenderer>().material = green;
        }

        if (ehm.currentHealth == 4)
        {
            HPSlot1.GetComponent<MeshRenderer>().material = green;
            HPSlot2.GetComponent<MeshRenderer>().material = green;
            HPSlot3.GetComponent<MeshRenderer>().material = green;
            HPSlot4.GetComponent<MeshRenderer>().material = green;
            HPSlot5.GetComponent<MeshRenderer>().material = white;
        }

        if (ehm.currentHealth == 3)
        {
            HPSlot1.GetComponent<MeshRenderer>().material = green;
            HPSlot2.GetComponent<MeshRenderer>().material = green;
            HPSlot3.GetComponent<MeshRenderer>().material = green;
            HPSlot4.GetComponent<MeshRenderer>().material = white;
            HPSlot5.GetComponent<MeshRenderer>().material = white;
        }

        if (ehm.currentHealth == 2)
        {
            HPSlot1.GetComponent<MeshRenderer>().material = green;
            HPSlot2.GetComponent<MeshRenderer>().material = green;
            HPSlot3.GetComponent<MeshRenderer>().material = white;
            HPSlot4.GetComponent<MeshRenderer>().material = white;
            HPSlot5.GetComponent<MeshRenderer>().material = white;
        }

        if (ehm.currentHealth == 1)
        {
            HPSlot1.GetComponent<MeshRenderer>().material = green;
            HPSlot2.GetComponent<MeshRenderer>().material = white;
            HPSlot3.GetComponent<MeshRenderer>().material = white;
            HPSlot4.GetComponent<MeshRenderer>().material = white;
            HPSlot5.GetComponent<MeshRenderer>().material = white;
        }

        showingBar = true;
    }

    void DontShowBar ()
    {
        HPSlot1.SetActive(false);
        HPSlot2.SetActive(false);
        HPSlot3.SetActive(false);
        HPSlot4.SetActive(false);
        HPSlot5.SetActive(false);
    }
}
