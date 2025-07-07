using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] float falltime = 0.5f, destroytime = 2f;
    Rigidbody2D rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Invoke("FallPlatform", falltime);
            Destroy(gameObject, destroytime);
        }
    }
    
    void FallPlatform()
    {
        rigid.isKinematic = false;
    }
}
