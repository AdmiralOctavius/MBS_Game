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
        //col.GameObject.toys++;
        //this.Destroy();
        Debug.Log("yeet");
    }
}
