using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalBeans : MonoBehaviour {

    public string currentBean;
    public string[] beanTypes;

	// Use this for initialization
	void Start ()
    {
        beanTypes[0] = "Ice";
        beanTypes[1] = "Explosion";
        beanTypes[2] = "Greasy";
        currentBean = beanTypes[Random.Range(0, beanTypes.Length)];
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (currentBean == "Ice")
            {
                DataHolder.IceBean += 1;
                Destroy(gameObject);
            }

            if (currentBean == "Explosion")
            {
                DataHolder.ExplosionBean += 1;
                Destroy(gameObject);
            }

            if (currentBean == "Greasy")
            {
                DataHolder.GreasyBean += 1;
                Destroy(gameObject);
            }
        }
    }
}
