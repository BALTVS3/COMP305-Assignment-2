using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapsingPlatform : MonoBehaviour
{
    private bool isBreaking = false; // Boolean for checking if the Player has caused the Platform to start Breaking

    void Update()
    {
        if (isBreaking) // If the Platform is Breaking...
        {
            Color textureColor = GetComponent<Renderer>().material.color; // Reduces Platform Opacity (Visually Distinct!), to show the Platform "Fading" (Crumbling)
            textureColor.a -= 0.005f;
            if (textureColor.a <= 0) // Once Opacity is 0, Destroy the Object (Cause it's gone.)
            {
                Destroy(gameObject);
            }
            GetComponent<Renderer>().material.color = textureColor; // (By now any transparent Platforms would be dead) Change platform color to reflect its gradually fading existence.
        }    
    }

    void OnCollisionEnter2D(Collision2D col) // If the Player jumps onto the Collapsing Platform, Platform is allowed to start Breaking.
    {
        if (col.gameObject.tag == "Player")
        {
            isBreaking = true;
        }
    }
}
