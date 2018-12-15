/*
 * Jenna Meador
 * Timer for MG1 - sets player variable and loads win scene when timer ends
 */

using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MG1Timer : MonoBehaviour
{
    public float timeLeft;

    Text text;

	void Start ()
    {
        text = GetComponent<Text>();
        timeLeft = 30.0f;
    }

    void Update ()
    {
        timeLeft -= Time.deltaTime;
        text.text = "Time Remaining: " + timeLeft.ToString("0.##");

        if (timeLeft <= 0.01f)
        {
            GetComponent<PlayerVariables>().SetPlayerVariable(0, 1);
            SceneManager.LoadScene("MG1YouWin");
        }
    }
}
