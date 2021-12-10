using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapsingPlatform : MonoBehaviour
{
    private bool isBreaking = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isBreaking)
        {
            Color textureColor = GetComponent<Renderer>().material.color;
            textureColor.a -= 0.005f;
            if (textureColor.a <= 0)
            {
                Destroy(gameObject);
            }
            GetComponent<Renderer>().material.color = textureColor;
        }    
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            isBreaking = true;
        }
    }
}
