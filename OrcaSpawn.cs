using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcaSpawn : MonoBehaviour
{
    public GameObject OrcaPrefab;
    public float DestroyDelay = 5f;
    public float minDelay = 1f;
    public float maxDelay = 7f;

    public AudioSource WaterSplash;

    void Start()
    {
        StartCoroutine(SpawnOrca());
    }

    IEnumerator SpawnOrca()
    {
        while (true)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);
            play();
        }
    }
    void play()
    {
        float SpawnX = Random.Range(0.05f, 12f);
        Vector3 SpawnPoint = new Vector3(SpawnX, -5, 0);
        GameObject SpawnedBall = Instantiate(OrcaPrefab, SpawnPoint, Quaternion.identity);
        WaterSplash.PlayDelayed(1f);
        Destroy(SpawnedBall, DestroyDelay);
    }
}
