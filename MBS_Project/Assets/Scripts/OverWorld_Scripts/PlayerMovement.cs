/*
 * Name: Trey, Isaac
 * Purpose: Script for moving around in the over world, now contains saved position for the play and animation control  
 * */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public GameObject UITest;

    
    // Use this for initialization
    void Start ()
    {
        if (PlayerPrefs.HasKey("playerOverworldX") && PlayerPrefs.HasKey("playerOverworldY"))
        {
            gameObject.transform.position = new Vector2(PlayerPrefs.GetFloat("playerOverworldX"), PlayerPrefs.GetFloat("playerOverworldY"));
        }
       
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (UITest.GetComponent<UI_Controller>().overworldUiOn == false)
        {
            if (Input.GetAxisRaw("Vertical") == 1)
            {
                gameObject.transform.position += new Vector3(0, 0.04f, 0);
                gameObject.GetComponent<Animator>().SetBool("isWalking", true);
            }

            else if (Input.GetAxisRaw("Vertical") == -1)
            {
                gameObject.transform.position += new Vector3(0, -0.04f, 0);
                gameObject.GetComponent<Animator>().SetBool("isWalking", true);
            }

            if (Input.GetAxisRaw("Horizontal") == 1)
            {
                gameObject.transform.position += new Vector3(0.04f, 0, 0);
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
                gameObject.GetComponent<Animator>().SetBool("isWalking", true);
            }

            if (Input.GetAxisRaw("Horizontal") == -1)
            {
                gameObject.transform.position += new Vector3(-0.04f, 0, 0);
                gameObject.GetComponent<SpriteRenderer>().flipX = false ;
                gameObject.GetComponent<Animator>().SetBool("isWalking", true);
            }

            if (Input.anyKey == true)
            {
                //keep walking
            }
            else
            {
                gameObject.GetComponent<Animator>().SetBool("isWalking", false  );
            }
        }
    }
}
