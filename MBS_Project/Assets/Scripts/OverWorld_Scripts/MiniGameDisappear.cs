using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameDisappear : MonoBehaviour
{

    public GameObject stats;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(stats.GetComponent<PlayerVariables>().BeatMinigame == 1)
        {
            Destroy(gameObject);
        }
    }
}
