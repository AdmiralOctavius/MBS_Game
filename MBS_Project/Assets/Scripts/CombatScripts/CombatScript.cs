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
    public Slider playerHPBar;
    public Slider enemyHPBar;
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

        enemyHPBar.maxValue = enemyHp;
        playerHPBar.maxValue = playerHp;
    }
	
	void Update ()
    {
		
	}

    void FixedUpdate()
    {
        if(enemyHp <= 0)
        {
            combatText.text = "You defeated the enemy!";
            StartCoroutine(CombatText(3));
            //StopCoroutine(CombatText(3));

            SceneManager.LoadScene("OverWorldMap");
        }
        if(playerHp <= 0)
        {
            combatText.text = "Your emotions have consumed you!";
            StartCoroutine(CombatText(3));
            combatText.text = "You Lose";
            StartCoroutine(CombatText(3));
            SceneManager.LoadScene("Menu");
        }
    }

    //Player attack function
    public void PlayerAttacking(int choice)
    {
        //StopCoroutine(CombatText());
        Debug.Log("The player attacked");
        combatText.text = "The player attacked the enemy and did " + playerAttack.ToString() + " damage!";

        StartCoroutine(CombatText(choice));
        

        enemyHp -= playerAttack;
        enemyHPBar.value = enemyHp;
    }

    //Players Breath
    public void Breath(int choice)
    {
        //works
        if(GetComponent<PlayerVariables>().BeatMinigame == 1)
        {
            combatText.text = "The player takes deep breaths, healing them for " + 15.ToString() + " health!";
            StartCoroutine(CombatText(choice));
       

            playerHp += 15;
            playerHPBar.value = playerHp;
        }
        else
        {
            combatText.text = "You do not have this ability.";
            StartCoroutine(CombatText(choice));
        }
    }

    //Enemey Attack Function
    public void EnemenyAttacking(int choice)
    {
        Debug.Log("The enemy attacked");
        combatText.text = "The enemy attacked the player and did " + enemyAttack.ToString() + " damage!";
        StartCoroutine(CombatText(choice));
       

        playerHp -= enemyAttack;
        playerHPBar.value = playerHp;
    }

    public void CombatForAttack()
    {
        if(playerSpeed >= enemySpeed)
        {
            PlayerAttacking(2);
            
            
        }
        else
        {
            EnemenyAttacking(0);
            
        }
    }

    public void ChoseBreath()
    {
        Breath(2);
    }

    IEnumerator CombatText(int choice)
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

                //choice is equvilent to attacks,0 = pa, 1= b, 2= ea, 3 = null
                if(choice == 0)
                {
                    PlayerAttacking(3);
                }
                else if(choice == 1)
                {
                    Breath(3);
                }
                else if(choice == 2)
                {
                    EnemenyAttacking(3);
                }
                else if( choice == 3)
                {
                    //Do nothing, coroutine ends
                }
            }

        }

    }
}
