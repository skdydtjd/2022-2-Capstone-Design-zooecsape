using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformSpawner : MonoBehaviour
{
    public GameObject platformprefab;
    public GameObject wallprefab;

    public int count = 10;
    public float speed = 3f;

    public float spawntimemin = 0.7f;
    public float spawntimemax = 1.5f;
    private float spawntime;

    public float yPos = -5f;
    private float xPos = 10f;

    private GameObject[] platforms;
    private int idx = 0;

    private Vector2 hidePos = new Vector2(0, -10);
    private float lastSpawnTime;

    private GameObject[] walls;
    private float randomPos;
    private float wallspawntime;

    void Start()
    {
        platforms = new GameObject[count];
        walls = new GameObject[count];

        for (int i = 0; i < count; i++)
        {
            platforms[i] = Instantiate(platformprefab, hidePos, Quaternion.identity);
            walls[i] = Instantiate(wallprefab, hidePos, Quaternion.identity);
        }

        lastSpawnTime = 0f;

        spawntime = 0f;
    }

    void Update()
    {
        for(int i = 0; i < count; i++)
        {
            platforms[i].transform.Translate(Vector2.left * speed * Time.deltaTime);
            walls[i].transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        if(Time.time >= lastSpawnTime + spawntime)
        {
            lastSpawnTime = Time.time;

            spawntime = Random.Range(spawntimemin, spawntimemax);

            platforms[idx].SetActive(false);
            platforms[idx].SetActive(true);
            
            platforms[idx].transform.position = new Vector2(xPos, yPos);
            
            if(Random.Range(1,10) < 3)
            {
                walls[idx].SetActive(false);
                walls[idx].SetActive(true);

                randomPos = Random.Range(-1f, 1f);
                walls[idx].transform.position = new Vector2(xPos + randomPos, yPos + 1.45f);
            }

            idx++;

            if(idx >= count)
            {
                idx = 0;
            }
        }
    }
}
