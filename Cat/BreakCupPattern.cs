using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakCupPattern : MonoBehaviour
{
    AudioSource breakCups;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            breakCups.Play();
            Destroy(gameObject, 0.3f);
        }

        if(collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Platform")
        {
            breakCups.Play();
            Destroy(gameObject, 0.3f);
        }
    }

    private void Awake()
    {
        breakCups = GetComponent<AudioSource>();
    }

    void Start()
    {

    }


    void Update()
    {
        Destroy(gameObject, 3f);
    }
}
