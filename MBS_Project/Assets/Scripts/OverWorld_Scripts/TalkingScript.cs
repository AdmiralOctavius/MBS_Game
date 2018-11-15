using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkingScript : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(Input.GetKey(KeyCode.Space))
        {
            Debug.Log("test");
        }
    }

}
