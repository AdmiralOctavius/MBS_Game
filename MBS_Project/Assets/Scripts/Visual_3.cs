/*
 * Name: Anthony
 * Purpose: VN filereader script for VN scene 2
 * * */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class Visual_3 : MonoBehaviour
{
    //We create the list that will hold the text coming in from the file
    public List<string> textHolder;

    //This is just a variable to hold the scene name so that we can change it through Unity later
    public string scene = "Battle3";

    //This is to show the current spot in the list
    int currentSpot = 0;

    //This is the textbox in Unity that use to manipulate to put the string in
    public Text textTab;

    //This is the current method to detect when we should change scenes
    int counter = 0;

    //This is how we will read in the content from the file
    StreamReader streamContent = new StreamReader("Speaking3.txt");

    // Use this for initialization
    void Start()
    {
        //This small method here will read the text from the file
        using (streamContent)
        {

            //This is the string variable that will be used to hold the text coming in from text file
            string linebyline;

            while ((linebyline = streamContent.ReadLine()) != null)
            {
                textHolder.Add(linebyline);
            }

            //An attempt was made to manipulate the string and remove the fist three characters coming in from the file. For now, i'll just manually change it in the text file itself
            //linebyline = linebyline.Remove(0, 3);
        }

    }

    // Update is called once per frame
    void Update()
    {
        //This is the debug method for changing text, in the end of it all, will probably remove this part 
        if (Input.GetMouseButtonDown(0))
        {
            currentSpot++;

            counter++;

            if (textHolder.Count - 1 > 0)
            {
                textTab.text = textHolder[currentSpot];
            }



        }

        //This is the main method for changing text
        if (Input.GetButtonDown("Submit"))
        {
            currentSpot++;

            counter++;

            if (textHolder.Count - 1 > 0)
            {
                textTab.text = textHolder[currentSpot];
            }

        }

        //If we raeach a certain nunmber of submits/clicks, change scene
        if (counter == 34)
        {
            SceneManager.LoadScene(scene);
        }


    }

}

