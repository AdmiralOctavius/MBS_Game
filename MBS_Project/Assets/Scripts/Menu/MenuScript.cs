using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        PlayerPrefs.DeleteAll();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log(Input.GetButton("Submit").ToString());
		if(Input.GetButtonDown("Submit"))
        {
            SceneManager.LoadScene("OverWorldMapUpdate");
        }
        else if(Input.GetButtonDown("Cancel"))
        {
            Application.Quit();
        }
	}
}
