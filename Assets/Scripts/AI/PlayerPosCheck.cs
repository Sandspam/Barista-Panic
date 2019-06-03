using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosCheck : MonoBehaviour
{
    public Vector3 initPlayerPos;

    private void OnEnable()
    {
        initPlayerPos = new Vector3(GameObject.Find("Player").transform.position.x, GameObject.Find("Player").transform.position.y, GameObject.Find("Player").transform.position.z);
    }
}
