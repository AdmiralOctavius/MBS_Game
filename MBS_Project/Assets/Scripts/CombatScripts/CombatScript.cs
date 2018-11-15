using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatScript : MonoBehaviour
{
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

    //Player attack function
    int PlayerAttacking()
    {
        enemyHp -= playerAttack;
        return enemyHp;
    }

    //Players Breath
    int Breath()
    {
        playerHp += 5;
        return playerHp;
    }

    //Enemey Attack Function
    int EnemenyAttacking()
    {
        playerHp -= enemyAttack;
        return playerHp;
    }
}
