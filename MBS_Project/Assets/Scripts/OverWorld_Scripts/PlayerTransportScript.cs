using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTransportScript : MonoBehaviour
{

    // public float xPos = 0;
    // public float yPos = 0;
    public GameObject endPoint;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Rigidbody2D>().WakeUp();
    }


    void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetButton("Submit"))
        {
            //Vector3 position = new Vector3(xPos, yPos);
            Vector3 position = endPoint.transform.position;

            Quaternion test = new Quaternion();

            collision.transform.SetPositionAndRotation(position, test);
        }
    }

}
