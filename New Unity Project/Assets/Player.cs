using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D body;
    private bool isOnPlatform = false;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        body.velocity = new Vector2(xAxis * 5f, body.velocity.y);
        if ((xAxis < 0) && (transform.localScale.x == 0.05f))
        {
            gameObject.transform.localScale -= new Vector3(0.1f, 0, 0);
        }
        else if (xAxis > 0 && transform.localScale.x == -0.05f)
        {
            gameObject.transform.localScale += new Vector3(0.1f, 0, 0);
        }

        if ((Input.GetButtonDown("Jump")) && (body.velocity.y == 0f || isOnPlatform)) // && body.velocity.y == 0f 
        {
            body.velocity = new Vector2(body.velocity.x, 5f);
        }

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Platform")
        {
            isOnPlatform = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Platform")
        {
            isOnPlatform = false;
        }
    }
}
