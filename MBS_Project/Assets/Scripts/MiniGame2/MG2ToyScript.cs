using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG2ToyScript : MonoBehaviour {

    //public bool hasToy;
    void Start()
    {
        //hasToy = false;
    }

    void Update() {
        

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        MG2PlayerScript.toys += 1;
        MG2ToyScript.Destroy(gameObject);
        Debug.Log("toys: " + MG2PlayerScript.toys);
    }
}
