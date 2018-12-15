/*
 * Jenna Meador
 * Camera script for MG2 - camera follows the player object
 */

 using UnityEngine;

public class MG2Camera : MonoBehaviour
{
    public GameObject followObject;

    void Update()
    {
        if (followObject)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(followObject.transform.position.x,
                followObject.transform.position.y, transform.position.z), .1f);
        }
    }
}
