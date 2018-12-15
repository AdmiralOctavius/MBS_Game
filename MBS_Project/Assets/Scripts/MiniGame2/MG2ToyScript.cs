/*
 * Jenna Meador
 * Toy script for MG2 - trigger for "picking up" toys
 */

using UnityEngine;

public class MG2ToyScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        MG2PlayerScript.toys += 1;
        MG2ToyScript.Destroy(gameObject);
        Debug.Log("toys: " + MG2PlayerScript.toys);
    }
}
