using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    public GameObject arrowPrefab;
    float span = 1.0f;
    float delta = 0;
    GameObject Game;

    private void Start()
    {
        Game = GameObject.Find("GameDirector");
    }
    // Update is called once per frame
    void Update()
    {
        if(Game.GetComponent<GameDirector>().isPlaying)
        {
            this.delta += Time.deltaTime;

            if (this.delta > this.span)
            {
                this.delta = 0;
                GameObject go = Instantiate(arrowPrefab);
                int px = Random.Range(-10, 10);
                go.transform.position = new Vector3(px, 7, 0);
            }
        }
    }
}
