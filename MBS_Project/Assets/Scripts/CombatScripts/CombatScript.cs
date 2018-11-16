using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CombatScript : MonoBehaviour
{
    public GameObject textCanvis;
    public Text combatText;
    bool time = true;

    //Im not calling GetComponent Every god damn time
    int playerAttack;
    int playerDeffense;
    int playerSpeed;
    int playerHp;

    int enemyAttack;
    int enemyDeffense;
    int enemySpeed;
    int enemyHp;

    void Start ()
    {
        //its ok to set the stats her ebecuase they wont need to be kept since fights wont be right after another
        playerAttack = GetComponent<PlayerStuff>().playerAttack;
        playerDeffense = GetComponent<PlayerStuff>().playerDeffense;
        playerSpeed = GetComponent<PlayerStuff>().playerSpeed;
        playerHp = GetComponent<PlayerStuff>().playerHp;

        enemyAttack = GetComponent<Enemy>().enemyAttack;
        enemyDeffense = GetComponent<Enemy>().enemyDeffense;
        enemySpeed = GetComponent<Enemy>().enemySpeed;
        enemyHp = GetComponent<Enemy>().enemyHp;
    }
	
	void Update ()
    {
		
	}

    void FixedUpdate()
    {
        if(enemyHp <= 0)
        {
            combatText.text = "You defeated the enemy!";
            StartCoroutine(CombatText());


            SceneManager.LoadScene("OverWorldMap");
        }
    }

    //Player attack function
    int PlayerAttacking()
    {
        
        combatText.text = "The player attacked the enemy and did " + playerAttack.ToString() + " damage!";
        StartCoroutine(CombatText());
        enemyHp -= playerAttack;
        return enemyHp;
    }

    //Players Breath
    int Breath()
    {
        //works
        combatText.text = "The player takes deep breaths, healing them for " + 6.ToString() + " health!";
        StartCoroutine(CombatText());
        playerHp += 6;
        return playerHp;
    }

    //Enemey Attack Function
    int EnemenyAttacking()
    {
        combatText.text = "The enemy attacked the player and did " + enemyAttack.ToString() + " damage!";
        StartCoroutine(CombatText());
        playerHp -= enemyAttack;
        return playerHp;
    }

    IEnumerator CombatText()
    {
        //if false will show text and blank bacground
        if(time == false)
        {
            GameObject.FindGameObjectWithTag("TextArea").SetActive(true);
            GameObject.FindGameObjectWithTag("CombatText").SetActive(true);
            time = true;
        }
        //when true will disable text and backgrounf, se to false, and wipe text
        else
        {
            GameObject.FindGameObjectWithTag("TextArea").SetActive(false);
            GameObject.FindGameObjectWithTag("CombatText").SetActive(false);
            time = false;
            combatText.text = "";
        }

        yield return new WaitForSeconds(2.5f); 
    }
}
