﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MG3PlayerHealth : MonoBehaviour {

    public float maxHealth = 15;
    private float health;

    private float score;

    public Text scoreText;
    public Text healthText;


    // Use this for initialization
    void Start ()
    {
        health = maxHealth;
        score = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
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
            SceneManager.LoadScene("MG3YouWin");
        }
    }
}
