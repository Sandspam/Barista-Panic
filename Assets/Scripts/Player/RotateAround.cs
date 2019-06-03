using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour {

    public GameObject worldCenter;
    public float rotateSpeed;

    void Start () 
    {
		
	}
	
	void Update () 
    {
        transform.RotateAround(worldCenter.transform.position, new Vector3(0, 0, 1), rotateSpeed);
        gameObject.transform.eulerAngles = new Vector3(gameObject.transform.rotation.x, gameObject.transform.rotation.y, 0);
	}
}
