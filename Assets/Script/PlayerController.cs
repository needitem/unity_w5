using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool isLBtnDown = false;
    private bool isRBtnDown = false;
    public float h = 0;
    GameObject Game;
    // Start is called before the first frame update
    void Start()
    {
        this.Game = GameObject.Find("GameDirector");
    }

    // Update is called once per frame
    void Update()
    {
        
        float border = 10.0f;

        if (this.Game.GetComponent<GameDirector>().isPlaying)

        if (isLBtnDown)
        {
            this.h = -1;
        }
        else if (isRBtnDown)
        {
            this.h = 1;
        }
        else
        { 
            this.h = Input.GetAxis("Horizontal");
        }
        
        if (Math.Abs(transform.position.x + h) < border)
        {
            transform.Translate(new Vector3(h / 20, 0, 0));
        }

    }
    

    public void onLbtnDown()
    {
        this.isLBtnDown = true;
    }
    public void onLbtnUp()
    {
        this.isLBtnDown = false;
    }

    public void onRbtnDown()
    {
        this.isRBtnDown = true;
    }
    public void onRbtnUp()
    {
        this.isRBtnDown = false;
    }

}
