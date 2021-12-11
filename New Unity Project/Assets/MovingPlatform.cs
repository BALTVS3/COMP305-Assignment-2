using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private Rigidbody2D body; // Create a variable to contain the Rigidbody to susequently use for all movements.
    private float yDir = 1; // Create a float for determining Platform Direction (Not exactly the way you did Platform Movements w/ PingPong, just set 2 Limited areas and had them move between the 2. PingPong's probably more condense, but oh well.)
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
