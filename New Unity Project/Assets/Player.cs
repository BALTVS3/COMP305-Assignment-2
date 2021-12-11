using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D body; // Create a variable to contain the Rigidbody to susequently use for all movements.
    private bool isOnPlatform = false; // Bool used to determine if the Player is on a Platform (I primarily allowed the Player to jump if their y velocity was 0, but that would mean no jumping on the Seesaw, Moving Platform OR the Swinging Platform.)
    void Start()
    {
        body = GetComponent<Rigidbody2D>(); // Initialize the body.
    }

    void Update()
    {

        float xAxis = Input.GetAxisRaw("Horizontal"); // Get Left/Right Movements
        body.velocity = new Vector2(xAxis * 5f, body.velocity.y); // If Horizontal Movements are being made, implement them (Keep the y the same just in case there's already movement)

        if ((xAxis < 0) && (transform.localScale.x == 0.05f)) // My own little trick for turning the sprite Left/Right, if you reverse the scaling it swaps the sprite direction.
        {
            gameObject.transform.localScale -= new Vector3(0.1f, 0, 0);
        }
        else if (xAxis > 0 && transform.localScale.x == -0.05f)
        {
            gameObject.transform.localScale += new Vector3(0.1f, 0, 0);
        }

        if ((Input.GetButtonDown("Jump")) && (body.velocity.y == 0f || isOnPlatform)) // If you're on either a Stable Platform/Ground OR an Unstable Platform (So, not in the air), you can Jump.
        {
            body.velocity = new Vector2(body.velocity.x, 5f);
        }


    }
    void OnCollisionEnter2D(Collision2D col) // On Collision with a Platform, allow Jumping (Otherwise you'd be screwed at half of the Platform types)
    {
        if (col.gameObject.tag == "Platform")
        {
            isOnPlatform = true;
        }
        else if (col.gameObject.tag == "MovingPlatform") // Added benefit for Moving Platform: Implement the Parent Trick to assist in Platform Movements.
        {
            isOnPlatform = true;
            transform.SetParent(col.transform);
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Platform") // After (Presumable) getting off the Platform via jump or fall, dissallow Jumping (No double jumps!)
        {
            isOnPlatform = false;
        }
        else if (col.gameObject.tag == "MovingPlatform") // Remove the Moving Platform benefits.
        {
            isOnPlatform = false;
            transform.SetParent(null);
        }
    }
}
