﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MG1Timer : MonoBehaviour
{
    public float timeLeft = 30.0f;
    //private bool haveWon;

    Text text;

	void Start ()
    {
        //timeLeft = 30.0f;
        text = GetComponent<Text>();

        //haveWon = false;
    }

    void Update ()
    {
        timeLeft -= Time.deltaTime;
        text.text = "Time Remaining: " + timeLeft.ToString("0.##");

        if (timeLeft <= 0.01f)
        {
            GetComponent<PlayerVariables>().SetPlayerVariable(0, 1);
            SceneManager.LoadScene("MG1YouWin");
            //haveWon = true;
        }
    }
}
