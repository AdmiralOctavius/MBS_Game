/*
 * Jenna Meador
 * Balloon script for MG1 - respawns balloon if it falls
 * past a certain point and causes to player to lose a life
 */

using UnityEngine;

public class MG1BalloonScript : MonoBehaviour {

    Vector2 respawnPoint;

    void Start ()
    {
        respawnPoint = transform.position;
    }
	
	void Update ()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if (transform.position.y <= -10)
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0;
            transform.rotation = Quaternion.identity;
            transform.position = respawnPoint;
            this.GetComponent<MG1Lives>().ChangeHealth(1.0f);
        }
    }
}
