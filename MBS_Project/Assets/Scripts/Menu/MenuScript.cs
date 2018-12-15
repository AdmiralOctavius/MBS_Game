using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    public GameObject screenFade;
    public bool isMainMenu;
    public string sceneName;
    // Use this for initialization
    void Start ()
    {
        PlayerPrefs.DeleteAll();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log(Input.GetButton("Submit").ToString());
		if(Input.GetButtonDown("Submit"))
        {
            if (isMainMenu == true)
            {
                StartCoroutine(FadeToBlack());
                Invoke("CallScene", 3);
            }
            else
            {
                Invoke("CallScene", 1);
            }
            

        }
        else if(Input.GetButtonDown("Cancel"))
        {
            Application.Quit();
        }
	}

    public void CallScene()
    {
        SceneManager.LoadScene(sceneName);
    }
    IEnumerator FadeToBlack()
    {
        while(screenFade.GetComponent<SpriteRenderer>().color.a != 1)
        {
            screenFade.GetComponent<SpriteRenderer>().color = new Color(screenFade.GetComponent<SpriteRenderer>().color.r , screenFade.GetComponent<SpriteRenderer>().color.g, screenFade.GetComponent<SpriteRenderer>().color.b, screenFade.GetComponent<SpriteRenderer>().color.a +  0.01f);
            yield return new WaitForFixedUpdate();
        }

    }
}
