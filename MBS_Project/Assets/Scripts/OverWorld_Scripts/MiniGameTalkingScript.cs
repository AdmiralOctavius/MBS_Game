﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameTalkingScript : MonoBehaviour
{

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
            SceneManager.LoadScene("JennaMiniGame");
        }
    }

}
