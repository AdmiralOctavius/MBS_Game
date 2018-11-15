using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (Input.GetAxisRaw("Vertical") == 1)
        {
            gameObject.transform.position += new Vector3(0, 0.04f, 0);
        }

        else if (Input.GetAxisRaw("Vertical") == -1)
        {
            gameObject.transform.position += new Vector3(0, -0.04f, 0);
        }

        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            gameObject.transform.position += new Vector3(0.04f, 0, 0);
        }

        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            gameObject.transform.position += new Vector3(-0.04f, 0, 0);
        }
    }
}
