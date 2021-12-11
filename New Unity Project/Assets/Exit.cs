using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D col) // When Player reaches the Exit door, You Win! (Could be done with Triggers, I admit I was lazy at this point.)
    {
        if (col.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("You Win");
        }
    }
}
