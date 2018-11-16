using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CombatScript : MonoBehaviour
{
    public GameObject textCanvis;
    public GameObject textElememnt;
    public Text combatText;
    bool time = false;



    //Im not calling GetComponent Every god damn time
    public int playerAttack;
    public int playerDeffense;
    public int playerSpeed;
    public int playerHp;
     
    public int enemyAttack;
    public int enemyDeffense;
    public int enemySpeed;
    public int enemyHp;

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
            StopCoroutine(CombatText());

            SceneManager.LoadScene("OverWorldMap");
        }
    }

    //Player attack function
    public void PlayerAttacking()
    {
        //StopCoroutine(CombatText());
        Debug.Log("The player attacked");
        combatText.text = "The player attacked the enemy and did " + playerAttack.ToString() + " damage!";

        StartCoroutine(CombatText());
        

        enemyHp -= playerAttack;
        
    }

    //Players Breath
    public void Breath()
    {
        //works
        
        combatText.text = "The player takes deep breaths, healing them for " + 15.ToString() + " health!";
        StartCoroutine(CombatText());
       

        playerHp += 15;
    }

    //Enemey Attack Function
    public void EnemenyAttacking()
    {
        Debug.Log("The enemy attacked");
        combatText.text = "The enemy attacked the player and did " + enemyAttack.ToString() + " damage!";
        StartCoroutine(CombatText());
       

        playerHp -= enemyAttack;
    }

    public void CombatForAttack()
    {
        if(playerSpeed >= enemySpeed)
        {
            PlayerAttacking();
            EnemenyAttacking();
        }
        else
        {
            EnemenyAttacking();
            PlayerAttacking();
        }
    }

    IEnumerator CombatText()
    {
        bool something = true;
        while (something)
        {
            //if false will show text and blank bacground
            if(time == false)
            {
                textCanvis.SetActive(true);
                textElememnt.SetActive(true);
                time = true;
                yield return new WaitForSeconds(2.5f); 
            }
            //when true will disable text and backgrounf, se to false, and wipe text
            else
            {
                textCanvis.SetActive(false);
                textElememnt.SetActive(false);
                time = false;
                //combatText.text = "";
                something = false;
            }

        }

    }
}
