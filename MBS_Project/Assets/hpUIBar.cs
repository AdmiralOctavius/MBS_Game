using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hpUIBar : MonoBehaviour {

    public float hptemp;

	// Use this for initialization
	void Start () {
        hptemp = 1;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(hptemp != 0)
        {
            hptemp = hptemp - 0.01f;
            transform.localScale = new Vector3(hptemp, transform.localScale.y);
        }

	}
}
