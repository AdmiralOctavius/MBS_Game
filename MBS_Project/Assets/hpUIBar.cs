using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpUIBar : MonoBehaviour {

    public float hptemp;
    public Slider slideme;

	// Use this for initialization
	void Start () {
        hptemp = 100;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(hptemp != 0)
        {
            hptemp = hptemp - 1f;
            slideme.value = hptemp;
        }

	}
}
