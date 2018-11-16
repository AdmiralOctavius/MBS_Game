using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MG1ButtonScript : MonoBehaviour
{
    public bool isPlay = true;

    public void Play()
    {
        Debug.Log("We clicked the play button");
        SceneManager.LoadScene("JennaMiniGame");
    }

    public void Quit()
    {
        SceneManager.LoadScene("OverWorldMap");
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
