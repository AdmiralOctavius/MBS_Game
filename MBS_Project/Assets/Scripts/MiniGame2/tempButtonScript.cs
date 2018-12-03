using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class tempButtonScript : MonoBehaviour {

    public bool isPlay = true;

    public void Play()
    {
        Debug.Log("We clicked the play button");
        GetComponent<PlayerVariables>().SetPlayerVariable(7, 1);
        SceneManager.LoadScene("MG2YouWin");
    }

    public void Quit()
    {
        SceneManager.LoadScene("OverWorldMapUpdate");
    }

    void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            if (isPlay == true)
                Play();
            else
                Quit();
        }

    }

    

}
