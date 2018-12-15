using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MG3PlayerHealth : MonoBehaviour {

    public float maxHealth = 15;
    private float health;
    private bool isDead;

    private float score;


    // Use this for initialization
    void Start ()
    {
        health = maxHealth;
        isDead = false;
        score = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void ChangeHealth(float damage)
    {
        health = Mathf.Min(health + damage, maxHealth);
        Debug.Log("health:" + health);
        if (health <= 0)
        {
            isDead = true;
            SceneManager.LoadScene("MG3YouLose");
        }
    }

    public void ChangeScore(float points)
    {
        score += points;
        Debug.Log("score:" + score);
        if (score >= 50)
        {
            SceneManager.LoadScene("MG3YouWin");
        }
    }
}
