using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float border = 10.0f;
        float h = Input.GetAxis("Horizontal");
        
        if (Math.Abs(transform.position.x + h) < border)
        {

            transform.Translate(new Vector3(h / 20, 0, 0));
        }

    }
}
