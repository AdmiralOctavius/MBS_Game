using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour {

    public List<GameObject> SelectableElementList;

    public int currentCursorPos = 0;
    public bool selectionInputHeld = false;

    public bool UIBattle = false;

    
	// Use this for initialization
	void Start () {
        //SelectableElementList = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Vertical Axis: " + Input.GetAxisRaw("Vertical").ToString() + " | Horizontal Axis: " + Input.GetAxisRaw("Horizontal").ToString());
        if(UIBattle == false)
        {

            if((Input.GetAxisRaw("Vertical") > 0.001f) && selectionInputHeld == false && Input.GetButtonDown("Vertical") ==true)
            {
                if (currentCursorPos - 1 < 0)
                {
                    currentCursorPos = SelectableElementList.Count - 1;
                }
                else
                {
                    currentCursorPos--;
                }
                selectionInputHeld = true;

            }
            else if((Input.GetAxisRaw("Vertical") < -0.001f) && selectionInputHeld == false && Input.GetButtonDown("Vertical") == true)
            {
                if (currentCursorPos + 1 > SelectableElementList.Count - 1)
                {
                    currentCursorPos = 0;
                }
                else
                {
                    currentCursorPos++;
                }
                selectionInputHeld = true;
            
            }
            else
            {
                //Nothing
                selectionInputHeld = false;
            }
       
            
        }
        else
        {
            /**
             * 
             *      0 | 1
             *      2 | 3
             * 
             * */

            if ((Input.GetAxisRaw("Horizontal") > 0.001f) && Input.GetButtonDown("Horizontal") == true)
            {
                //Limit to either 0 - 1 or 2-3
                if(currentCursorPos + 1 == 1 || currentCursorPos + 1 == 3)
                {
                    currentCursorPos++;
                }
                else
                {
                    //Nothing
                }

            }
            else if((Input.GetAxisRaw("Horizontal") < 0.001f) && Input.GetButtonDown("Horizontal") == true)
            {
                //Limit to either 0 - 1 or 2-3
                if(currentCursorPos - 1 == 0 || currentCursorPos - 1 == 2)
                {
                    currentCursorPos--;
                }
                else
                {
                    //Nothing
                }

            }
            else
            {
                //Nothing
                //selectionInputHeld = false;
            }

            if ((Input.GetAxisRaw("Vertical") > 0.001f)  && Input.GetButtonDown("Vertical") == true)
            {
                //Need to limit this to 0th and 2nd position or 1st and 3rd pos.
                
                if (currentCursorPos - 2 == 0 || currentCursorPos - 2 == 1)
                {
                    currentCursorPos = currentCursorPos - 2;
                }
                else
                {
                    
                }

            }
            else if ((Input.GetAxisRaw("Vertical") < -0.001f) && Input.GetButtonDown("Vertical") == true)
            {
                //Need to limit this to 0th and 2nd position or 1st and 3rd pos.
                if (currentCursorPos + 2 == 2 || currentCursorPos + 2 == 3)
                {
                    currentCursorPos = currentCursorPos + 2;
                }
                else
                {
                    
                }

            }
            else
            {
                //Nothing
                //selectionInputHeld = false;
            }

            
        }

        if (Input.GetButtonDown("Submit") == true)
        {
            Debug.Log("Got the submit on element: " + currentCursorPos + ". Which Should call: " + SelectableElementList[currentCursorPos].gameObject.GetComponentInChildren<Text>().text);
            //This is where the call to a specific action would be on the ActionMenu
        }
    }
}
