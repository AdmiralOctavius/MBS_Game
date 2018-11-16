using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MG1Timer : MonoBehaviour
{
    private float timeLeft;

    Text text;

	void Start ()
    {
        timeLeft = 3.0f;
        text = GetComponent<Text>();
    }

    void Update ()
    {
        timeLeft -= Time.deltaTime;
        text.text = "Time Remaining: " + timeLeft.ToString("0.##");

        if (timeLeft <= 0.01f)
            SceneManager.LoadScene("MG1YouWin");
    }
}
