using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3Fish : MonoBehaviour
{
    public float speed = 5f;
    public AudioSource TakeFish;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left*speed*Time.deltaTime);

        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            if (GameManager.instance != null)
            {
                GameManager.instance.fishcount += 0.5f;

                if(GameManager.instance.fishcount >= 15f)
                {
                    GameManager.instance.fishcount = 15f;
                }
            }
        }
    }
}
