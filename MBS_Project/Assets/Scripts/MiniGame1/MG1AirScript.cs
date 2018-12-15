/*
 * Jenna Meador
 * Air script for MG1 - controls "puff" of air from player
 */

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

