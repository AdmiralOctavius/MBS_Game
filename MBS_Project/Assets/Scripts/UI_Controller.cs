using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Controller : MonoBehaviour {

    public List<GameObject> SelectableElementList;
    public AudioSource clicker;
    //For Battle scene


    public int currentCursorPos = 0;
    public bool selectionInputHeld = false;

    public bool UIBattle = false;

    public bool overworldUiOn = false;
    public GameObject startPos;
    public GameObject endPos;

    public float journeyLength;
    float currentPercentage;
    public float speed = 1f;
    public float startTime;

    public bool confirmExit = false;
    public GameObject confirmBox;
    public GameObject confirmBoxStart;
    public GameObject confirmBoxEnd;
    public float confirmArrowPos;

    public bool itemMenuUp = false;
    public GameObject itemMenuObj;
    public GameObject itemMenuStart;
    public GameObject itemMenuEnd;
    public GameObject item1Obj;
    public GameObject item2Obj;
    public GameObject item3Obj;

    public GameObject mainBattleUI;
    public bool attackMenu;
    public GameObject attackMenuUI;
    public bool magicMenu;
    public GameObject magicMenuUI;
    public bool itemMenu;
    public GameObject itemMenuUI;

    public GameObject combatController;

    public bool menuUI;

    public GameObject playerVariables;

    // Use this for initialization
    void Start() {
        if (UIBattle == false)
        {
           
                //SelectableElementList = new List<GameObject>();
                this.transform.position = startPos.transform.position;
                 itemMenuObj.transform.position = itemMenuStart.transform.position;

                // Calculate the journey length.
                journeyLength = Vector3.Distance(startPos.transform.position, endPos.transform.position);

                //confirmBox.transform.position = confirmBoxStart.transform.position;
                QuitBoxSwap();

            

        }

        if (playerVariables.GetComponent<PlayerVariables>().BeatMinigame == 1)
        {   
            item1Obj.SetActive(true);
        }
        if (playerVariables.GetComponent<PlayerVariables>().BeatMinigame2 == 1)
        {
            item2Obj.SetActive(true);
        }
        if (playerVariables.GetComponent<PlayerVariables>().BeatMinigame3 == 1)
        {
            item3Obj.SetActive(true);
        }


    }

    // Update is called once per frame
    void Update()
    {
      
        //Debug.Log("Vertical Axis: " + Input.GetAxisRaw("Vertical").ToString() + " | Horizontal Axis: " + Input.GetAxisRaw("Horizontal").ToString());
        if (UIBattle == false)
        {
            if (overworldUiOn == true)
            {
                if (confirmExit == true)
                {
                    if (Input.GetAxisRaw("Horizontal") == 1)
                    {
                        if (confirmArrowPos + 1 == 1)
                        {
                            confirmArrowPos++;
                        }
                    }
                    else if (Input.GetAxisRaw("Horizontal") == -1)
                    {
                        if (confirmArrowPos - 1 == 0)
                        {
                            confirmArrowPos--;
                        }
                    }
                }
                else
                {

                    if (Input.GetAxisRaw("Vertical") == 1 && (selectionInputHeld != true))
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
                        itemMenuObj.SetActive(false);
                        itemMenuUp = false;
                    }
                    else if (Input.GetAxisRaw("Vertical") == -1 && (selectionInputHeld != true))
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
                        itemMenuObj.SetActive(false);
                        itemMenuUp = false;
                    }
                    else if(Input.GetAxisRaw("Vertical") == 0)
                    {
                        //Nothing
                        selectionInputHeld = false;
                    }
                    //Debug.Log(Input.GetAxisRaw("Vertical").ToString());
                    //Debug.Log(selectionInputHeld.ToString());
                }
            }
            else if (menuUI)
            {
                if (Input.GetAxisRaw("Vertical") == 1 && (selectionInputHeld != true))
                {
                    if (currentCursorPos - 1 < 0)
                    {
                        currentCursorPos = SelectableElementList.Count - 1;
                    }
                    else
                    {
                        currentCursorPos--;
                    }
                    selectionInputHeld = false;

                }
                else if (Input.GetAxisRaw("Vertical") == -1 && (selectionInputHeld != true))
                {
                    if (currentCursorPos + 1 > SelectableElementList.Count - 1)
                    {
                        currentCursorPos = 0;
                    }
                    else
                    {
                        currentCursorPos++;
                    }
                    selectionInputHeld = false;

                }
                else
                {
                    selectionInputHeld = true;
                }
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

            if (Input.GetAxisRaw("Horizontal") == 1)
            {
                //Limit to either 0 - 1 or 2-3
                if (currentCursorPos + 1 == 1 || currentCursorPos + 1 == 3)
                {
                    currentCursorPos++;
                }
                else
                {
                    //Nothing
                }

            }
            else if (Input.GetAxisRaw("Horizontal") == -1)
            {
                //Limit to either 0 - 1 or 2-3
                if (currentCursorPos - 1 == 0 || currentCursorPos - 1 == 2)
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

            if (Input.GetAxisRaw("Vertical") == 1)
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
            else if (Input.GetAxisRaw("Vertical") == -1)
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
            if (UIBattle == true)
            {

                if (combatController.GetComponent<CombatScript>().time == false)
                {

                    Debug.Log("Got the submit on element: " + currentCursorPos + ". Which Should call: " + SelectableElementList[currentCursorPos].gameObject.GetComponentInChildren<Text>().text);
                    Debug.Log("Attack menu:" + attackMenu.ToString() + "| magic menu:" + magicMenu.ToString() + "item menu:" + itemMenu.ToString());
                    Debug.Log("Current Cursor Pos: " + currentCursorPos);
                    //This is where the call to a specific action would be on the ActionMenu
                    if (attackMenu || magicMenu || itemMenu)
                    {
                        if (attackMenu)
                        {
                            if (currentCursorPos == 0)
                            {
                                Debug.Log("This gets attack1");

                                combatController.GetComponent<CombatScript>().CombatForAttack();
                                Debug.Log("Enemy hp: " + combatController.GetComponent<CombatScript>().enemyHp);
                                Debug.Log("Player Health: " + combatController.GetComponent<CombatScript>().playerHp);

                            }
                            else if (currentCursorPos == 1)
                            {
                                combatController.GetComponent<CombatScript>().PlayerDefending(3);
                                Debug.Log("Enemy hp: " + combatController.GetComponent<CombatScript>().enemyHp);
                                Debug.Log("Player Health: " + combatController.GetComponent<CombatScript>().playerHp);

                            }
                            else if (currentCursorPos == 2)
                            {
                                combatController.GetComponent<CombatScript>().EnemenyAttacking(8);
                                Debug.Log("Enemy hp: " + combatController.GetComponent<CombatScript>().enemyHp);
                                Debug.Log("Player Health: " + combatController.GetComponent<CombatScript>().playerHp);

                            }
                            else
                            {
                                mainBattleUI.SetActive(true);
                                attackMenuUI.SetActive(false);
                                magicMenuUI.SetActive(false);
                                itemMenuUI.SetActive(false);

                                itemMenu = false;
                                magicMenu = false;
                                attackMenu = false;
                            }
                        }
                        else if (magicMenu)
                        {
                            if (currentCursorPos == 0)
                            {
                                if (GetComponent<PlayerVariables>().BeatMinigame == 1)
                                {
                                    combatController.GetComponent<CombatScript>().EnemenyAttacking(1);
                                    //combatController.GetComponent<CombatScript>().Breath();
                                    Debug.Log("Enemy hp: " + combatController.GetComponent<CombatScript>().enemyHp);
                                    Debug.Log("Player Health: " + combatController.GetComponent<CombatScript>().playerHp);
                                }
                                else
                                {
                                    combatController.GetComponent<CombatScript>().Breath(3);
                                }
                            }
                            else if (currentCursorPos == 1)
                            {
                                if (GetComponent<PlayerVariables>().BeatMinigame2 == 1)
                                {
                                    combatController.GetComponent<CombatScript>().EnemenyAttacking(5);
                                    Debug.Log("Enemy hp: " + combatController.GetComponent<CombatScript>().enemyHp);
                                    Debug.Log("Player Health: " + combatController.GetComponent<CombatScript>().playerHp);
                                }
                                else
                                {
                                    combatController.GetComponent<CombatScript>().Relaxing(3);
                                }
                            }
                            else if (currentCursorPos == 2)
                            {
                                if (GetComponent<PlayerVariables>().BeatMinigame3 == 1)
                                {
                                    combatController.GetComponent<CombatScript>().EnemenyAttacking(6);
                                    Debug.Log("Enemy hp: " + combatController.GetComponent<CombatScript>().enemyHp);
                                    Debug.Log("Player Health: " + combatController.GetComponent<CombatScript>().playerHp);
                                }
                                else
                                {
                                    combatController.GetComponent<CombatScript>().Hobby(3);
                                }
                            }
                            else
                            {
                                mainBattleUI.SetActive(true);
                                attackMenuUI.SetActive(false);
                                magicMenuUI.SetActive(false);
                                itemMenuUI.SetActive(false);

                                itemMenu = false;
                                magicMenu = false;
                                attackMenu = false;
                            }
                        }
                        else if (itemMenu)
                        {
                            if (currentCursorPos == 0)
                            {

                            }
                            else if (currentCursorPos == 1)
                            {

                            }
                            else if (currentCursorPos == 2)
                            {

                            }
                            else
                            {
                                mainBattleUI.SetActive(true);
                                attackMenuUI.SetActive(false);
                                magicMenuUI.SetActive(false);
                                itemMenuUI.SetActive(false);

                                itemMenu = false;
                                magicMenu = false;
                                attackMenu = false;
                            }
                        }
                    }
                    else
                    {
                        if (SelectableElementList[currentCursorPos].gameObject.GetComponentInChildren<Text>().text == "Attack")
                        {
                            mainBattleUI.SetActive(false);
                            attackMenuUI.SetActive(true);
                            attackMenu = true;
                        }
                        else if (SelectableElementList[currentCursorPos].gameObject.GetComponentInChildren<Text>().text == "Item")
                        {
                            mainBattleUI.SetActive(false);
                            itemMenuUI.SetActive(true);
                            itemMenu = true;
                        }
                        else if (SelectableElementList[currentCursorPos].gameObject.GetComponentInChildren<Text>().text == "Run")
                        {
                            mainBattleUI.SetActive(true);
                            attackMenuUI.SetActive(false);
                            magicMenuUI.SetActive(false);
                            itemMenuUI.SetActive(false);

                            itemMenu = false;
                            magicMenu = false;
                            attackMenu = false;
                        }
                        else if (SelectableElementList[currentCursorPos].gameObject.GetComponentInChildren<Text>().text == "Magic" && (GetComponent<PlayerVariables>().BeatMinigame == 1))
                        {
                            Debug.Log("Got here");
                            mainBattleUI.SetActive(false);
                            magicMenuUI.SetActive(true);
                            if (GetComponent<PlayerVariables>().BeatMinigame != 1)
                            {
                                magicMenuUI.transform.GetChild(0).gameObject.SetActive(false);
                            }

                            if (GetComponent<PlayerVariables>().BeatMinigame2 != 1)
                            {
                                magicMenuUI.transform.GetChild(1).gameObject.SetActive(false);
                            }

                            if (GetComponent<PlayerVariables>().BeatMinigame3 != 1)
                            {
                                magicMenuUI.transform.GetChild(2).gameObject.SetActive(false);
                            }

                            magicMenu = true;
                        }
                    }
                }

            }
            else if (menuUI)
            {
                Debug.Log(SelectableElementList[currentCursorPos].gameObject.GetComponentInChildren<Text>().text.ToString());
                if (SelectableElementList[currentCursorPos].gameObject.GetComponentInChildren<Text>().text == "Play")
                {
                    SceneManager.LoadScene("OverWorldMap");
                }
                else if (SelectableElementList[currentCursorPos].gameObject.GetComponentInChildren<Text>().text == "Quit")
                {
                    Debug.Log("Got to quit call");
                    Application.Quit();
                }
                else if(SelectableElementList[currentCursorPos].gameObject.GetComponentInChildren<Text>().text == "Inventory")
                {
                    
                    if (itemMenuUp == true)
                    {
                        //Nothing
                        Debug.Log("Got to inventory call");
                        //StopCoroutine(UiTransfer(true));
                        //StopAllCoroutines();
                        //StartCoroutine(UiTransfer(true));
                        itemMenuUp = false;
                        itemMenuObj.SetActive(false);
                        
                    }
                    else if(itemMenuUp == false)
                    {
                        //Nothing

                        //StopCoroutine(UiTransfer(true));
                        //StartCoroutine(UiTransfer(true));
                        itemMenuObj.SetActive(true);
                     
                        itemMenuUp = true;
                    }
                    Debug.Log(itemMenuUp.ToString());
                }
                

                if (confirmExit == true)
                {
                    if (confirmArrowPos == 0)
                    {
                        //Exit
                        Debug.Log("Exit point");
                        SceneManager.LoadScene("Menu");
                    }
                    else
                    {
                        //Return to normal
                        confirmExit = false;
                        QuitBoxSwap();
                    }
                }
                else
                {
                    if (SelectableElementList[currentCursorPos].gameObject.GetComponentInChildren<Text>().text == "Quit")
                    {
                        Debug.Log("Got here");
                        confirmExit = true;
                        QuitBoxSwap();
                    }
                }

            }

        }





        if (Input.GetButtonDown("Cancel"))
        { 


            if (UIBattle == false)
            {
                if (confirmExit)
                {
                    confirmExit = false;
                    QuitBoxSwap();
                }
                else
                {

                    if (overworldUiOn)
                    {
                        overworldUiOn = false;
                        startTime = Time.time;

                        itemMenuObj.SetActive(false);
                        itemMenuUp = false;
                        clicker.Play();
                        //Debug.Log("Calling coroutine");
                        StopCoroutine(UiTransfer(false));
                        StartCoroutine(UiTransfer(false));

                    }
                    else
                    {
                        overworldUiOn = true;
                        startTime = Time.time;
                        //Debug.Log("Calling coroutine");
                        clicker.Play();
                        StopCoroutine(UiTransfer(false));
                        StartCoroutine(UiTransfer(false));
                    }
                }
            }
        

            }

        //Debug.Log(overworldUiOn.ToString());
        //Debug.Log(confirmExit.ToString());
    }

    IEnumerator UiTransfer(bool itemUI)
    {


        //Debug.Log("got here in coroutine");
        if (overworldUiOn)
        {
            if(itemUI == true){

                if (itemMenuUp == false)
                {
                    while (itemMenuObj.GetComponent<Transform>().position != itemMenuStart.GetComponent<Transform>().position)
                    {
                        // Distance moved = time * speed.
                        float distCovered = (Time.time - startTime) * speed;

                        // Fraction of journey completed = current distance divided by total distance.
                        float fracJourney = distCovered / journeyLength;


                        //currentPercentage = Mathf.PingPong(Time.time, speed);
                        itemMenuObj.GetComponent<Transform>().position = Vector3.Lerp(itemMenuStart.GetComponent<Transform>().position, itemMenuEnd.GetComponent<Transform>().position, fracJourney);
                        //Debug.Log("got here in coroutine");
                        yield return new WaitForFixedUpdate();
                        


                    }
                }
                else {

                    while (itemMenuObj.GetComponent<Transform>().position != itemMenuEnd.GetComponent<Transform>().position)
                    {
                        // Distance moved = time * speed.
                        float distCovered = (Time.time - startTime) * speed;

                        // Fraction of journey completed = current distance divided by total distance.
                        float fracJourney = distCovered / journeyLength;


                        //currentPercentage = Mathf.PingPong(Time.time, speed);
                        itemMenuObj.GetComponent<Transform>().position = Vector3.Lerp(itemMenuEnd.GetComponent<Transform>().position, itemMenuStart.GetComponent<Transform>().position, fracJourney);
                        
                        yield return new WaitForFixedUpdate();
                        
                            
                        Debug.Log("Set itemMenuUp: " + itemMenuUp.ToString());
                    }
                }

            }
            else
            {


                //Move down
                //this.transform.position = endPos.transform.position;
                while (transform.position != endPos.transform.position)
                {
                    // Distance moved = time * speed.
                    float distCovered = (Time.time - startTime) * speed;

                    // Fraction of journey completed = current distance divided by total distance.
                    float fracJourney = distCovered / journeyLength;


                    //currentPercentage = Mathf.PingPong(Time.time, speed);
                    transform.position = Vector3.Lerp(startPos.transform.position, endPos.transform.position, fracJourney);
                    //Debug.Log("got here in coroutine");
                    yield return new WaitForFixedUpdate();
                }
            }
        }
        else
        {
            
                //Move up
                //this.transform.position = startPos.transform.position;
                while (transform.position != startPos.transform.position)
                {
                    // Distance moved = time * speed.
                    float distCovered = (Time.time - startTime) * speed;

                    // Fraction of journey completed = current distance divided by total distance.
                    float fracJourney = distCovered / journeyLength;


                    //currentPercentage = Mathf.PingPong(Time.time, speed);
                    transform.position = Vector3.Lerp(endPos.transform.position, startPos.transform.position, fracJourney);
                    Debug.Log("got here in coroutine");
                    yield return new WaitForFixedUpdate();
                }
            
        }

        
    }

    void QuitBoxSwap()
    {
        if(confirmExit == true)
        {
            confirmBox.transform.position = confirmBoxEnd.transform.position;
        }
        else
        {
            Debug.Log("Got to swap call");
            confirmBox.transform.position = confirmBoxStart.transform.position;
            
        }
    }
}
