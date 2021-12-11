using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyPlatform : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D col) // Visual distinctness for the Bouncy Platform (Most of the Bouncy's special stuff is done via the Physics Material, so all that's needed is the Visually Distinct Visual Cue)
    {
        if (col.gameObject.tag == "Player")
        {
            gameObject.GetComponent<Renderer>().material.color = Color.cyan;
        }
    }

    void OnCollisionExit2D(Collision2D col) // After the player bounces, remove the Visually Distinct Visual Cue.
    {
        if (col.gameObject.tag == "Player")
        {
            gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
    }
}
