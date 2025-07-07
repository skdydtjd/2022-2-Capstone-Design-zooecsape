using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowFruitPattern : MonoBehaviour
{
    public Rigidbody2D rb;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject, 0.3f);
        }
    }

    private void Start()
    {
        rb.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(8,2) * Random.Range(-1f,-3f);
    }

    private void Update()
    {
        Destroy(gameObject, 3f);
    }
}
