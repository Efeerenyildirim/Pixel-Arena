using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject pink;
    public GameObject blue;

    Vector3 pinkSpawnPoint = new Vector3(-90f, 0f, 0f);
    Vector3 blueSpawnPoint = new Vector3(90f, 0f, 0f);

    void Start()
    {
        StartCoroutine(SpawnPink());
        StartCoroutine(SpawnBlue());
    }

    void Update()
    {

    }

    IEnumerator SpawnPink()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1f, 2f));
            Instantiate(pink, pinkSpawnPoint, Quaternion.identity);
        }
    }

    IEnumerator SpawnBlue()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1f, 2f));
            Instantiate(blue, blueSpawnPoint, Quaternion.identity);
        }
    }

}
