using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGBalloonScript : MonoBehaviour {

    Vector2 respawnPoint;

    // Use this for initialization
    void Start () {
       // Globals.playerObject = gameObject;//4th way to reference a gameobject from another - have the gameobject tell the other one about itself instead of vice versa
        respawnPoint = transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        

        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if (transform.position.y <= -10)
        {
            rb.velocity = Vector2.zero;
            transform.position = respawnPoint;
        }
    }
}
