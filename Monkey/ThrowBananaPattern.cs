using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBananaPattern : MonoBehaviour
{
    public Rigidbody2D rb;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject, 0.3f);
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
        rb.AddForce(new Vector2(-0.2f,0),ForceMode2D.Impulse);

        Destroy(gameObject, 3f);
    }
}
