using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextChanging : MonoBehaviour {

    public List<string> textHolder;

    //string currentText;

    int currentSpot = 0;

    public Text textTab;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            currentSpot++;

            //textHolder[currentSpot];
            //current = textHolder[i];
            

            textTab.text = textHolder[currentSpot];
        }
	}
}
