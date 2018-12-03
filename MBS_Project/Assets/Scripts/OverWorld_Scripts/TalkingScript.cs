using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TalkingScript : MonoBehaviour
{

    public GameObject playerVars;
    public GameObject player;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.GetComponent<Rigidbody2D>().WakeUp();
	}
    

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Input.GetButton("Submit"))
            {
                playerVars.GetComponent<PlayerVariables>().SetPlayerVariable(5, player.transform.position.x);
                playerVars.GetComponent<PlayerVariables>().SetPlayerVariable(6, player.transform.position.y);
                SceneManager.LoadScene("Visual 1");
            }
        }
    }

}
