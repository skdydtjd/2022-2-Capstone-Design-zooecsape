using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }
}
