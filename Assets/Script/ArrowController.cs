using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class ArrowController : MonoBehaviour
{
    GameObject director;
    GameObject player;
    float speed = -0.02f;
    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("player");
        this.director = GameObject.Find("GameDirector");
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(0, speed, 0);

        if (transform.position.y < -5.0f)
        {
            GameObject.Find("GameDirector").GetComponent<GameDirector>().score++;
            Destroy(gameObject);
        }

        Vector2 p1 = transform.position;
        Vector2 p2 = this.player.transform.position;

        float distance = (p1- p2).magnitude;

        float r1 = 0.5f; float r2 = 1.0f;

        if (distance < r1 + r2)
        {
            director.GetComponent<GameDirector>().DecreaseHp();

            Destroy(gameObject);
        }


        if(!GameObject.Find("GameDirector").GetComponent<GameDirector>().isPlaying)
        {
            speed = 0.0f;
        }
        speed *= 1.003f;

    }



}

