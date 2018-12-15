/*
 * Name: Isaac
 * Purpose: Deletes the minigame npc if the minigame is completed
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameDisappear : MonoBehaviour
{

    public GameObject stats;
    public int miniGame;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(stats.GetComponent<PlayerVariables>().BeatMinigame == 1 && miniGame == 1)
        {
            Destroy(gameObject);
        }
        if (stats.GetComponent<PlayerVariables>().BeatMinigame == 7 && miniGame == 7)
        {
            Destroy(gameObject);
        }
        if (stats.GetComponent<PlayerVariables>().BeatMinigame == 8 && miniGame == 8)
        {
            Destroy(gameObject);
        }
    }
}
