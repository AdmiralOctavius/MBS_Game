﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTransportScript : MonoBehaviour
{

    public float xPos = 0;
    public float yPos = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetButton("Submit"))
        {
            Vector3 position = new Vector3(xPos, yPos);

            Quaternion test = new Quaternion();

            collision.transform.SetPositionAndRotation(position, test);
        }
    }

}