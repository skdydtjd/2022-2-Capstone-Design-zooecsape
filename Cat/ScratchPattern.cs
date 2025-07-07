using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScratchPattern : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject, 0.3f);
        }
    }

    private void Start()
    {

    }

    private void Update()
    {
        Destroy(gameObject, 2f);
    }
}
