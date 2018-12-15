﻿/*
 * Jenna Meador
 * Button script for MG2 - controls button in menu/win/lose scenes
 */

using UnityEngine.SceneManagement;
using UnityEngine;

public class MG2ButtonScript : MonoBehaviour
{
    public bool isPlay = true;

    public void Play()
    {
        Debug.Log("We clicked the play button");
        SceneManager.LoadScene("MG2GamePlay");
    }

    public void Quit()
    {
        SceneManager.LoadScene("OverWorldMapUpdate");
    }

    void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            if (isPlay == true)
                Play();
            else
                Quit();
        }

    }
}
