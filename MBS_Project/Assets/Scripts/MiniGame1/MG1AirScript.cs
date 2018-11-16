using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG1AirScript : MonoBehaviour
{
    void Start()
    {
        Invoke("DieOff", .5f);

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

