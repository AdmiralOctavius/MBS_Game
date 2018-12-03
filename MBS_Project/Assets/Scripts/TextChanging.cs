using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class TextChanging : MonoBehaviour {

    public List<string> textHolder;

    public string scene = "FightSceenTest";

    int currentSpot = 0;

    public Text textTab;

    int counter = 0;

    StreamReader streamContent = new StreamReader("Speaking.txt");

// Use this for initialization
void Start () {
        using (streamContent)
        {
            string linebyline;

            while ((linebyline = streamContent.ReadLine()) != null)
            {
                textHolder.Add(linebyline);
            }
        }

    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            currentSpot++;

            counter++;

            if (textHolder.Count - 1 > 0)
            {
                textTab.text = textHolder[currentSpot];
            }

       

    }

        if (Input.GetButtonDown("Submit"))
        {
            currentSpot++;
            counter++;
            if (textHolder.Count - 1 > 0)
            {
                textTab.text = textHolder[currentSpot];
            }

        }

        if (counter == 30)
        {
            SceneManager.LoadScene(scene);
        }


    }


}
