using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carSpawn : MonoBehaviour
{
    public SpriteRenderer Sprite;
    public GameObject car;
    public bool isTouch;

    AudioSource carSound;

    // Start is called before the first frame update
    void Start()
    {
        isTouch = true;
        Sprite = GetComponent<SpriteRenderer>();
        carSound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        Sprite.enabled = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && isTouch)
        {
            car.GetComponent<Monster4Controller>().isMoved = true;
            carSound.Play();

        }
    }
}
