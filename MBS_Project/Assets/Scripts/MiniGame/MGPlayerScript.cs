using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGPlayerScript : MonoBehaviour
{
    public GameObject laser;
    public float fireRate = 2;//lasers per second

    private float lastFireTime = float.MinValue;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    
        if (laser == null)
            Debug.Log("You forgot to hook a laser prefab into this variable dummy!");
        else if (Input.GetAxis("Laser") > 0)
        {
            if (Time.time - (1 / fireRate) > lastFireTime)
            {
                GameObject obj = Instantiate(laser, transform.GetChild(0).position, transform.rotation);
                //Hue Saturation Value
                //Hue - color 
                //Saturation - how much color
                //Value - lightness/darkness
                obj.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0, 1, 1, 1, 1, 1);
                lastFireTime = Time.time;
            }
        }


    }

    void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            gameObject.transform.position += new Vector3(0.1f, 0, 0);
        }

        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            gameObject.transform.position += new Vector3(-0.1f, 0, 0);
        }

        
    }
}
