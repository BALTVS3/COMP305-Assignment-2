using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private Rigidbody2D body;
    public float yDir = 1;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y >= 2) 
        {
            yDir = -1f;
        }

        if (gameObject.transform.position.y <= -2)
        {
            yDir = 1f;
        }
        body.velocity = new Vector2(0, yDir);
    }
}
