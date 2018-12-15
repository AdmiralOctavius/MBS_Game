/*
 * Jenna Meador
 * Projectile script for MG3 - controls projectiles that player fires
 */

using UnityEngine;

public class MG3ProjectileScript : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        Invoke("DieOff", 2);

        gameObject.GetComponent<Rigidbody2D>().velocity = (10 * gameObject.transform.right);
	}
	
    void DieOff()
    {
        Destroy(gameObject);
    }
}
