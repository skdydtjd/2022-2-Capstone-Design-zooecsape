using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBG : MonoBehaviour
{
    [Range(1f, 20f)] public float speed = 1f;

    Vector2 initPos = new Vector2(17.7f, -0.3f);

    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed);

        if (transform.position.x < -17.7f)
        {
            transform.position = initPos;
        }
    }
}
