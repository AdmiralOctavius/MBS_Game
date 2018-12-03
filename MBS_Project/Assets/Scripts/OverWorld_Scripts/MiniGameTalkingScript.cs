﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameTalkingScript : MonoBehaviour
{

    public GameObject playerVars;
    public GameObject player;

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
            playerVars.GetComponent<PlayerVariables>().SetPlayerVariable(5, player.transform.position.x);
            playerVars.GetComponent<PlayerVariables>().SetPlayerVariable(6, player.transform.position.x);

            SceneManager.LoadScene("MG1MainMenu");
        }
    }

}
