using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] Fishes;
    public GameObject bomb;

    public float xBounds, yBound;

    void Start()
    {
        StartCoroutine(SpawnRandomGameObject());
    }

    IEnumerator SpawnRandomGameObject()
    {
        yield return new WaitForSeconds(Random.Range(1, 2));

        int randomFish = Random.Range(0, Fishes.Length);


        if (Random.value <= .6f)
            Instantiate(Fishes[randomFish],
                new Vector2(Random.Range(-xBounds, xBounds), yBound), Quaternion.identity);
        else
            Instantiate(bomb,
                new Vector2(Random.Range(-xBounds, xBounds), yBound), Quaternion.identity);

        StartCoroutine(SpawnRandomGameObject());
    }

}
