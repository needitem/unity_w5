using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    GameObject director;
    GameObject player;
    [SerializeField] float speed = -0.02f;
    [SerializeField] float destroyHeight = -5.0f;
    [SerializeField] float speedMultiplier = 1.003f;
    [SerializeField] float playerRadius = 1.0f;
    [SerializeField] float arrowRadius = 0.5f;

    void Start()
    {
        player = GameObject.Find("player");
        director = GameObject.Find("GameDirector");
    }

    void Update()
    {
        transform.Translate(0, speed, 0);

        if (transform.position.y < destroyHeight)
        {
            director.GetComponent<GameDirector>().score++;
            Destroy(gameObject);
        }

        Vector2 arrowPosition = transform.position;
        Vector2 playerPosition = player.transform.position;

        float distance = (arrowPosition - playerPosition).magnitude;

        if (distance < playerRadius + arrowRadius)
        {
            director.GetComponent<GameDirector>().DecreaseHp();
            Destroy(gameObject);
        }

        if (!director.GetComponent<GameDirector>().isPlaying)
        {
            speed = 0.0f;
        }

        speed *= speedMultiplier;
    }
}
