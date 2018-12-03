using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class TextChanging : MonoBehaviour {

    public List<string> textHolder;

    //string currentText;

    int currentSpot = 0;

    public Text textTab;

    FileStream content = new FileStream("Speaking.txt", FileMode.Open, FileAccess.Read);

    //StreamReader inp_stm = new StreamReader("Speaking.txt");

    //void readTextFile(string file_path)
    //{
    //    while (!inp_stm.EndOfStream)
    //    {
    //        string inp_ln = inp_stm.ReadLine();
    //
    //        foreach (var read in inp_ln)
    //        {
    //            textHolder.Add(str(read));
    //        }
    //    }
    //
    //    inp_stm.Close();
    //}

    // Use this for initialization
    void Start () {
        using (var streamContent = new StreamReader(content))
        {
            string linebyline;
            while ((linebyline = streamContent.ReadLine()) != null)
            {
                textHolder.Add(linebyline);
            }
        }


            //readTextFile("Speaking.txt");

    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            currentSpot++;

            textTab.text = textHolder[currentSpot];
        }
	}
}
