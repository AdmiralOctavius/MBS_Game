﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TalkingScript : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.GetComponent<Rigidbody2D>().WakeUp();
	}
    

    void OnTriggerStay2D(Collider2D collision)
    {
        if(Input.GetButton("Submit"))
        {
            SceneManager.LoadScene("Visual 1");
        }
    }

}
