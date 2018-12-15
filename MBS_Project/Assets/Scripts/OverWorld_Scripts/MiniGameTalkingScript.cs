/*
 * Name: Trey, Isaac
 * Purpose: Minigame talking script, same as npc
 * */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameTalkingScript : MonoBehaviour
{

    public GameObject playerVars;
    public GameObject player;
    public string miniGameScene;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Input.GetButton("Submit"))
            {
                playerVars.GetComponent<PlayerVariables>().SetPlayerVariable(5, player.transform.position.x);
                playerVars.GetComponent<PlayerVariables>().SetPlayerVariable(6, player.transform.position.y);

                SceneManager.LoadScene(miniGameScene);
            }
        }
    }

}
