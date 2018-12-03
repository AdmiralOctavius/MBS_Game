using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG2ToyScript : MonoBehaviour {

    public bool hasToy;
    // Use this for initialization
    void Start()
    {
        hasToy = false;
    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
       // if (col.gameObject == Globals.playerObject)
        //{
            
        //}
    }
}
