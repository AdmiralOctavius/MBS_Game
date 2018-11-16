using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetButton("Submit"))
        {
            SceneManager.LoadScene("OverWorldMap");
        }
        else if(Input.GetButton("Cancel"))
        {
            Application.Quit();
        }
	}
}
