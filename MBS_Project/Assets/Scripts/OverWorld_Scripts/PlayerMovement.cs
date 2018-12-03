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
            }

            else if (Input.GetAxisRaw("Vertical") == -1)
            {
                gameObject.transform.position += new Vector3(0, -0.04f, 0);
            }

            if (Input.GetAxisRaw("Horizontal") == 1)
            {
                gameObject.transform.position += new Vector3(0.04f, 0, 0);
            }

            if (Input.GetAxisRaw("Horizontal") == -1)
            {
                gameObject.transform.position += new Vector3(-0.04f, 0, 0);
            }
        }
    }
}
