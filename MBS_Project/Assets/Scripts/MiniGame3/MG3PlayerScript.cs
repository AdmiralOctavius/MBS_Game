/*
 * Jenna Meador
 * Player script for MG3 - controls player movement
 */

using UnityEngine;

public class MG3PlayerScript : MonoBehaviour
{
    public float speed;
    public float fireRate;
    private float lastFireTime = float.MinValue;

    public GameObject projectile;

	void Start ()
    {
        speed = 2;
        fireRate = 2;

	}
	
	void Update ()
    {
        if (Input.GetAxis("Jump") > 0)
        {
            if (Time.time - (1 / fireRate) > lastFireTime)
            {
                Instantiate(projectile, transform.GetChild(0).position, transform.rotation);
                lastFireTime = Time.time;
            }
        }
	}

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
            gameObject.transform.Rotate(0, 0, 150 * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            gameObject.transform.Rotate(0, 0, -150 * Time.deltaTime);
    }
}
