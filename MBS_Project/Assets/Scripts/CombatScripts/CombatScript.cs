/*
 * Names: Kris, Isaac
 * Purpose: Combat controller and combat text controller
 * */


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
    public bool time = false;
    public bool fullOut = false;

    public bool hasSmoked = false;
    public int smokingDelay;

    public bool hasRelaxed = false;
    public int relaxDelay;

    public bool hasHobby = false;
    public int hobbyDelay;


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

            SceneManager.LoadScene("OverWorldMapUpdate");
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
        //time = false;

        enemyHp -= playerAttack;
        enemyHPBar.value = enemyHp;
    }

    public void PlayerDefending(int choice)
    {
        combatText.text = "The player braces for the attack and takes 0 damage!";
        StartCoroutine(CombatText(choice));
        
    }

    public void PlayerFullOutAttack(int choice)
    {
        combatText.text = "The player puts all their energy into this attack, dealing " + (playerAttack * 2).ToString() + " damage!";
        StartCoroutine(CombatText(choice));

        fullOut = true;
        enemyHp -= (playerAttack * 2);
        enemyHPBar.value = enemyHp;
    }

    //Players Breath
    public void Breath(int choice)
    {
        //works
        if(GetComponent<PlayerVariables>().BeatMinigame == 1)
        {
            combatText.text = "The player takes deep breaths, helping them calm down. They heal for " + 15.ToString() + " health!";
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

    public void Smoking(int choice)
    {
        //if
        if(hasSmoked == false)
        {
            combatText.text = "The player takes out a cigerate and starts to smoke! They heal for " + 30.ToString() + " health but loose " + 2.ToString() + " attack and " + 6.ToString() + " to speed!";
            StartCoroutine(CombatText(choice));

            playerHp += 30;
            playerAttack -= 2;
            playerSpeed -= 6;
            hasSmoked = true;
        }
        else
        {
            combatText.text = "Your lungs have not yet recovered.";
            StartCoroutine(CombatText(choice));
        }
    }

    public void Relaxing(int choice)
    {
        if (GetComponent<PlayerVariables>().BeatMinigame == 2)
        {
            combatText.text = "The player sists down and finds a happy place in their mind, allowing them to relax. Thier Attack increases by 2 and all atacks are reduced by 2 for 3 turns!";
            StartCoroutine(CombatText(choice));

            playerAttack += 2;
            enemyAttack -= 2;
            hasRelaxed = true;
        }

        else
        {
            combatText.text = "You do not have this ability.";
            StartCoroutine(CombatText(choice));
        }
    }

    public void Hobby(int choice)
    {
        if (GetComponent<PlayerVariables>().BeatMinigame == 3)
        {
            combatText.text = "The player starts to work on a hobby, confusing the monster! The monster has a chance to miss its attacks for 5 turns!";
            StartCoroutine(CombatText(choice));

            hasHobby = true;
        }
    }

    //Enemey Attack Function
    public void EnemenyAttacking(int choice)
    {
        if(hasHobby == false)
        {
            Debug.Log("The enemy attacked");
            combatText.text = "The enemy attacked the player and did " + enemyAttack.ToString() + " damage!";
            StartCoroutine(CombatText(choice));
       

            playerHp -= enemyAttack;
            playerHPBar.value = playerHp;
        }
        else
        {
            int evasion = Random.Range(1, 100);
            Debug.Log(evasion);

            if(evasion > 25)
            {
                Debug.Log("The enemy attacked");
                combatText.text = "The enemy attacked the player and did " + enemyAttack.ToString() + " damage!";
                StartCoroutine(CombatText(choice));


                playerHp -= enemyAttack;
                playerHPBar.value = playerHp;
            }
            else 
            {
                combatText.text = "The enemy attacked the hobby instead of the player!";
                StartCoroutine(CombatText(choice));
            }
        }
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

                //counts down turns till you can smoke, dont do it it gives you cancer!
                while(hasSmoked == true)
                {
                    if(smokingDelay == 0)
                    {
                        hasSmoked = false;
                        combatText.text = "Your lungs feel better... You could use a smoke.";
                        playerAttack += 2;
                        playerSpeed += 6;
                    }
                    else
                        smokingDelay -= 1;
                }

                //counts down till you can relax, its needed rust me, Im a programer...
                while(hasRelaxed == true)
                {
                    if(relaxDelay == 0)
                    {
                        hasRelaxed = false;
                        combatText.text = "You no longer feel relaxed.";
                        playerAttack -= 2;
                        enemyAttack += 2;
                    }
                }

                //choice is equvilent to attacks,0 = pa, 1= b, 2= ea, 3 = null
                //player attack
                if(choice == 0)
                {
                    PlayerAttacking(3);
                }
                //breath
                else if(choice == 1)
                {
                    Breath(3);
                }
                //enamy attack
                else if(choice == 2)
                {
                    EnemenyAttacking(3);
                }
                //exits turn
                else if( choice == 3)
                {
                    //Do nothing, coroutine ends
                    if (fullOut == true)
                    {
                        combatText.text = "You need to catch your breath after that attack.";
                        fullOut = false;
                        StartCoroutine(CombatText(2));

                    }   
                }
                //smokes
                else if( choice == 4)
                {
                    smokingDelay = 3;
                    Smoking(3);
                }
                //relax
                else if(choice == 5)
                {
                    relaxDelay = 3;
                    Relaxing(3);
                }
                //hobby
                else if(choice == 6)
                {
                    hobbyDelay = 5;
                    Hobby(3);
                }
                //defend
                else if(choice == 7)
                {
                    PlayerDefending(3);
                }
                //fullout
                else if(choice == 8)
                {
                    PlayerFullOutAttack(3);
                }
            }

        }

    }
}
