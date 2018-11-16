using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGAirScript : MonoBehaviour
{
    void Start()
    {
        Invoke("DieOff", .5f);//Handy function for calling another function after x seconds

        //Addforce doesn't work for a Kinematic rigid body, but you can change its velocity directly.
        gameObject.GetComponent<Rigidbody2D>().velocity = (10 * gameObject.transform.up);
    }

    void Update()
    {

    }

    void DieOff()
    {
        Destroy(gameObject);
    }
}

