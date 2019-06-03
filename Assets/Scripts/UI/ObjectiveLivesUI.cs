using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveLivesUI : MonoBehaviour
{


    private void Update()
    {
        gameObject.GetComponent<Text>().text = "Objective Lives: " + GameObject.Find("Desk").GetComponent<Objective>().objectiveLives;
    }
}
