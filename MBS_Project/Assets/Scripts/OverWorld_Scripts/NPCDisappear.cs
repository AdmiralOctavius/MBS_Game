/*
 * Name: Trey
 * Purpose: Removes npc after talking to them
 * */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDisappear : MonoBehaviour
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
    }
}
