/*
 * Jenna Meador, Isaac Bennett (SetPlayerVariable)
 * Health script for MG3 - controls health and score of player,
 * prints health and score, and handles win/lose scene
 */

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MG3PlayerHealth : MonoBehaviour {

    public float maxHealth = 15;
    private float health;

    private float score;

    public Text scoreText;
    public Text healthText;

    void Start ()
    {
        health = maxHealth;
        score = 0;
    }

    public void ChangeHealth(float damage)
    {
        health = Mathf.Min(health + damage, maxHealth);
        //Debug.Log("health:" + health);

        if (healthText)
            healthText.text = "Health: " + health.ToString();

        if (health <= 0)
        {
            SceneManager.LoadScene("MG3YouLose");
        }
    }

    public void ChangeScore(float points)
    {
        score += points;
        //Debug.Log("score:" + score);

        if (scoreText)
            scoreText.text = "Score: " + score.ToString();

        if (score >= 50)
        {
            GetComponent<PlayerVariables>().SetPlayerVariable(8, 1);
            SceneManager.LoadScene("MG3YouWin");
        }
    }
}
