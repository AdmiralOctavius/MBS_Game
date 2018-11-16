using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MG1Lives : MonoBehaviour
{
    public float maxHealth = 3;

    private float health;
    private bool isDead;

    void Start()
    {
        health = maxHealth;
        isDead = false;
    }

    void Update()
    {
        if (isDead == true)
            SceneManager.LoadScene("MG1YouLose");
    }

    public void ChangeHealth(float changeAmt)
    {
        health -= changeAmt;
        if (health <= 0)
            isDead = true;
    }

}
