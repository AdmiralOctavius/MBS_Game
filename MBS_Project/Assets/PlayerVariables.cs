using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVariables : MonoBehaviour {

    public int BeatMinigame = 0;
    public int BeatMinigame2 = 0;
    public int BeatMinigame3 = 0;

    public int PlayerAttack = 0;
    public int PlayerHP = 0;
    public int PlayerDefense = 0;
    public int PlayerSpeed = 0;

    // Use this for initialization
    void Start()
    {

        if (PlayerPrefs.HasKey("BeatMinigame"))
        {
            BeatMinigame = PlayerPrefs.GetInt("BeatMinigame");
        }
        if (PlayerPrefs.HasKey("PlayerAttack"))
        {
            PlayerAttack = PlayerPrefs.GetInt("PlayerAttack");
        }
        if (PlayerPrefs.HasKey("PlayerHP"))
        {
            PlayerHP = PlayerPrefs.GetInt("PlayerHP");
        }
        if (PlayerPrefs.HasKey("PlayerDefense"))
        {
            PlayerDefense = PlayerPrefs.GetInt("PlayerDefense");
        }
        if (PlayerPrefs.HasKey("PlayerSpeed"))
        {
            PlayerSpeed = PlayerPrefs.GetInt("PlayerSpeed");
        }
    }
    
    //Variable to change is between 0-4 for beatminigame to player speed, input is for the new stat variable, this should be cumulative of previous stat and new increase
    public void SetPlayerVariable(int variableToChange, int input)
    {
        if(variableToChange == 0)
        {
            PlayerPrefs.SetInt("BeatMinigame",input);
        }
        else if(variableToChange == 1)
        {
            PlayerPrefs.SetInt("PlayerAttack", input);
        }
        else if(variableToChange == 2)
        {
            PlayerPrefs.SetInt("PlayerHP", input);
        }
        else if(variableToChange == 3)
        {
            PlayerPrefs.SetInt("PlayerDefense", input);
        }
        else if(variableToChange == 4)
        {
            PlayerPrefs.SetInt("PlayerSpeed", input);
        }
        else
        {
            Debug.Log("Inproper input");
        }

    }

    public void DeletePlayerVariables(int variableToChange, int value)
    {
        if (variableToChange == 0)
        {
            PlayerPrefs.DeleteKey("BeatMinigame");
        }
        else if (variableToChange == 1)
        {
            PlayerPrefs.DeleteKey("PlayerAttack");
        }
        else if (variableToChange == 2)
        {
            PlayerPrefs.DeleteKey("PlayerHP");
        }
        else if (variableToChange == 3)
        {
            PlayerPrefs.DeleteKey("PlayerDefense");
        }
        else if (variableToChange == 4)
        {
            PlayerPrefs.DeleteKey("PlayerSpeed");
        }
        else
        {
            Debug.Log("Inproper input");
        }
    }

}
