using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour {

    public GameObject uiController;
    public float UIxOffset = 2.75f;
	// Use this for initialization
	void Start () {
        //Sets the arrow to the position of the 0th element
        gameObject.transform.position = uiController.GetComponent<UI_Controller>().SelectableElementList[0].gameObject.transform.position;
        gameObject.transform.position = new Vector2(gameObject.transform.position.x - UIxOffset, gameObject.transform.position.y);
        Debug.Log(uiController.GetComponent<UI_Controller>().SelectableElementList[0].gameObject.transform.position.ToString());
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = uiController.GetComponent<UI_Controller>().SelectableElementList[uiController.GetComponent<UI_Controller>().currentCursorPos].gameObject.transform.position;
        gameObject.transform.position = new Vector2(gameObject.transform.position.x - UIxOffset, gameObject.transform.position.y);
    }
}
