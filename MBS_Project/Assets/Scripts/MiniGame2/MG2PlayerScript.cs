/*
 * Jenna Meador, Isaac Bennett (SetPlayerVariable)
 * Player script for MG2 - controls button in menu/win/lose scenes
 */

using UnityEngine.SceneManagement;
using UnityEngine;

public class MG2PlayerScript : MonoBehaviour
{
    public float speed;
    public static int toys = 0;

    void Start()
    {
        toys = 0;
        speed = 5;
    }

    void Update()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if (Input.GetKeyDown(KeyCode.Space)) //borrowed from Platformer class example 
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

                    rb.AddForce(Vector2.up * 320);

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

        if (toys == 5)
        {
            GetComponent<PlayerVariables>().SetPlayerVariable(7, 1);
            SceneManager.LoadScene("MG2YouWin");

        }    
    }
}

