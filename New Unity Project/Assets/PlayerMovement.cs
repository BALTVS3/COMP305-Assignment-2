using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        body.velocity = new Vector2(xAxis * 7f, body.velocity.y);
        if ((xAxis < 0) && (transform.localScale.x == 0.25f))
        {
            gameObject.transform.localScale -= new Vector3(0.5f, 0, 0);
        }
        else if (xAxis > 0 && transform.localScale.x == -0.25f)
        {
            gameObject.transform.localScale += new Vector3(0.5f, 0, 0);
        }

        if (Input.GetButtonDown("Jump")) 
        {
            body.velocity = new Vector2(body.velocity.x, 8f);
        }

    }
}
