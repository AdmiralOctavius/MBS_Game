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

    public float playerOverworldX = 0;
    public float playerOverworldY = 0;

    // Use this for initialization
    void Start()
    {

        if (PlayerPrefs.HasKey("BeatMinigame"))
        {
            BeatMinigame = PlayerPrefs.GetInt("BeatMinigame");
        }
        if (PlayerPrefs.HasKey("BeatMinigame2"))
        {
            BeatMinigame2 = PlayerPrefs.GetInt("BeatMinigame2");
        }
        if (PlayerPrefs.HasKey("BeatMinigame3"))
        {
            BeatMinigame3 = PlayerPrefs.GetInt("BeatMinigame3");
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
        if (PlayerPrefs.HasKey("playerOverworldX"))
        {
            playerOverworldX = PlayerPrefs.GetInt("playerOverworldX");
        }
        if (PlayerPrefs.HasKey("playerOverworldY"))
        {
            playerOverworldY = PlayerPrefs.GetInt("playerOverworldYs");
        }
    }
    
    //Variable to change is between 0-4 for beatminigame to player speed, input is for the new stat variable, this should be cumulative of previous stat and new increase
    public void SetPlayerVariable(int variableToChange, float input)
    {
        if(variableToChange == 0)
        {
            PlayerPrefs.SetInt("BeatMinigame",(int)input);
        }
        else if(variableToChange == 1)
        {
            PlayerPrefs.SetInt("PlayerAttack", (int)input);
        }
        else if(variableToChange == 2)
        {
            PlayerPrefs.SetInt("PlayerHP", (int)input);
        }
        else if(variableToChange == 3)
        {
            PlayerPrefs.SetInt("PlayerDefense", (int)input);
        }
        else if(variableToChange == 4)
        {
            PlayerPrefs.SetInt("PlayerSpeed", (int)input);
        }
        else if(variableToChange == 5)
        {
            PlayerPrefs.SetFloat("playerOverworldX", input);
        }
        else if(variableToChange == 6)
        {
            PlayerPrefs.SetFloat("playerOverworldY", input);
        }
        else if (variableToChange == 7)
        {
            PlayerPrefs.SetInt("BeatMinigame2", (int)input);
        }
        else if (variableToChange == 8)
        {
            PlayerPrefs.SetInt("BeatMinigame3", (int)input);
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
        else if (variableToChange == 5)
        {
            PlayerPrefs.DeleteKey("playerOverworldX");
        }
        else if (variableToChange == 6)
        {
            PlayerPrefs.DeleteKey("playerOverworldY");
        }
        else if (variableToChange == 7)
        {
            PlayerPrefs.DeleteKey("BeatMinigame2");
        }
        else if (variableToChange == 8)
        {
            PlayerPrefs.DeleteKey("BeatMinigame3");
        }
        else
        {
            Debug.Log("Inproper input");
        }
    }

}
