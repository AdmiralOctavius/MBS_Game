using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TalkingScript : MonoBehaviour
{

    public GameObject playerVars;
    public GameObject player;
    public bool TalkedTo = false;
    public string targetScene;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.GetComponent<Rigidbody2D>().WakeUp();

        if(TalkedTo == true)
        {
            Destroy(gameObject);
        }
	}
    

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Input.GetButton("Submit"))
            {
                playerVars.GetComponent<PlayerVariables>().SetPlayerVariable(5, player.transform.position.x);
                playerVars.GetComponent<PlayerVariables>().SetPlayerVariable(6, player.transform.position.y);
                TalkedTo = true;
                SceneManager.LoadScene(targetScene);
            }
        }
    }

}
