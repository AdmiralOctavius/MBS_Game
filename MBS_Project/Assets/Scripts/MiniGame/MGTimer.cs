using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MGTimer : MonoBehaviour
{
    private float timeLeft;

    Text text;

	void Start ()
    {
        timeLeft = 30.0f;
        text = GetComponent<Text>();
    }

    void Update ()
    {
        timeLeft -= Time.deltaTime;
        text.text = "Time Remaining: " + timeLeft;
    }
}
