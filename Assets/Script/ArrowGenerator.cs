using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    public GameObject arrowPrefab;
    private float spawnInterval = 1.0f;
    private float timeSinceLastSpawn = 0.0f;
    private GameObject gameDirector;
    private static List<GameObject> spawnedArrows = new List<GameObject>();

    private void Start()
    {
        gameDirector = GameObject.Find("GameDirector");
    }

    private void Update()
    {
        if (gameDirector.GetComponent<GameDirector>().isPlaying)
        {
            timeSinceLastSpawn += Time.deltaTime;

            if (timeSinceLastSpawn > spawnInterval)
            {
                timeSinceLastSpawn = 0;
                GameObject arrow = Instantiate(arrowPrefab);
                int xPosition = Random.Range(-10, 10);
                arrow.transform.position = new Vector3(xPosition, 7, 0);
                spawnedArrows.Add(arrow);
            }
        }
    }

    public void DestroyAll()
    {
        foreach (GameObject arrow in spawnedArrows)
        {
            Destroy(arrow);
        }

        spawnedArrows.Clear();
    }
}
