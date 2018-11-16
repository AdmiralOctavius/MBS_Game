﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG1BalloonScript : MonoBehaviour {

    Vector2 respawnPoint;

    void Start () {
        respawnPoint = transform.position;
    }
	
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