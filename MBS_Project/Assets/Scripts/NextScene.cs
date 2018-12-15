/*
 * Name: Anthony
 * Purpose: VN script to load next scene
 * */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //For debugging purposes, this will be the method used until controller is implemented
		if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Visual 2");
        }

        //Main method for changing scene
        if (Input.GetButtonDown("Submit"))
        {
            SceneManager.LoadScene("Visual 2");
        }
    }
}
