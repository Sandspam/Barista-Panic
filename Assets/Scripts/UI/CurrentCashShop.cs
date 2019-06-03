using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentCashShop : MonoBehaviour {

    public bool tutorial;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        gameObject.GetComponent<Text>().text = "$" + DataHolder.SpendCoins;
	}
}
