﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG1PlayerScript : MonoBehaviour
{
    public GameObject puff;
    public float puffRate = 2;

    private float lastPuffTime = float.MinValue;

    void Start()
    {
        
    }

    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = (0 * gameObject.transform.up);


        if (Input.GetAxis("Jump") > 0)
        {
            if (Time.time - (1 / puffRate) > lastPuffTime)
            {
                GameObject obj = Instantiate(puff, transform.GetChild(0).position, transform.rotation);
                obj.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0, 1, 1, 1, 1, 1);
                lastPuffTime = Time.time;
            }
        }
    }

    void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            gameObject.transform.position += new Vector3(0.1f, 0, 0);
        }

        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            gameObject.transform.position += new Vector3(-0.1f, 0, 0);
        }
    }
}
