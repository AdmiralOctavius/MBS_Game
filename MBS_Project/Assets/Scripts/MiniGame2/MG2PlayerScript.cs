using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG2PlayerScript : MonoBehaviour
{
    public float speed = 0, walkSpeed = 5, sprintSpeed = 15;
    public int toys = 0;

    public void SetRespawnPoint(Vector2 vec)
    {
    }

    void Start()
    {
    }

    void Update()//More responsive - checks our input each frame
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if (Input.GetKey(KeyCode.LeftShift))
            speed = sprintSpeed;
        else
            speed = walkSpeed;


        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Check if we are on the ground right now
            GameObject feet = transform.GetChild(0).gameObject;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(feet.transform.position, .5f);
            foreach (Collider2D col in colliders)
            {
                //Don't jump off ourselves
                if (col.gameObject != this.gameObject)
                {
                    rb.velocity = new Vector2(rb.velocity.x, 0);//Ignore previous falling velocity so we jump the full amount each time.

                    rb.AddForce(Vector2.up * 400);

                    break;
                }
            }
        }
    }
    void RestartCollider()
    {
        Collider2D col = GetComponent<Collider2D>();
        col.enabled = true;
    }
    void FixedUpdate()
    {
        //Handle left and right movement
        float movement = Input.GetAxis("Horizontal") * speed;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(movement, rb.velocity.y, 0);

        if (Input.GetKey(KeyCode.S))
        {
            Collider2D col = GetComponent<Collider2D>();
            col.enabled = false;
            Invoke("RestartCollider", .45f);
        }

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (movement > 0)
            sr.flipX = false;
        else if (movement < 0)
            sr.flipX = true;

       /* Animator anim = GetComponent<Animator>();

        if (Mathf.Abs(movement - 0) > float.Epsilon)
            anim.SetBool("isWalking", true);
        else
            anim.SetBool("isWalking", false);*/
    }
}

