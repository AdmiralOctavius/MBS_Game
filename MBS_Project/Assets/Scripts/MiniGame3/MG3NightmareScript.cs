using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG3NightmareScript : MonoBehaviour
{
    public float damageAmount;
    public float pointAmount;

    // Use this for initialization
    void Start ()
    {
        damageAmount = 5.0f;
        Invoke("DieOff", 3);
        pointAmount = 5.0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);

        if (col.gameObject.tag == "Sleeper")
        {
            col.gameObject.GetComponent<MG3PlayerHealth>().ChangeHealth(-damageAmount);
        }
        if (col.gameObject.tag == "Sleeper")
        {
            col.gameObject.GetComponent<MG3PlayerHealth>().ChangeScore(pointAmount);

        }
        //if player - change health
        //if projectile - destroy col.gameObject - change score
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(gameObject);

    }

    void DieOff()
    {
        Destroy(gameObject);
    }
}
