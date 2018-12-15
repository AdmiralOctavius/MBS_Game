using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG3ProjectileScript : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        Invoke("DieOff", 2);

        gameObject.GetComponent<Rigidbody2D>().velocity = (10 * gameObject.transform.right);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void DieOff()
    {
        Destroy(gameObject);
    }
}
