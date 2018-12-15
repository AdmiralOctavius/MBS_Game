/*
 * Jenna Meador
 * Lives for MG1 - keeps track of player lives and loads lose scene if 0
 */

using UnityEngine.SceneManagement;
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
