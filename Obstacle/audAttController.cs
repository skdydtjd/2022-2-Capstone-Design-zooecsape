using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audAttController : MonoBehaviour
{
    GameObject cameraFlash;
    AudioSource flashNoise;

    public SpriteRenderer Sprite;

    // Start is called before the first frame update
    void Start()
    {
        cameraFlash = GameObject.Find("flash");
        Sprite = GetComponent<SpriteRenderer>();
        flashNoise = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Sprite.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            cameraFlash.GetComponent<cameraFlash>().changed = true;

            StartCoroutine(Enable());

            other.gameObject.GetComponent<Player>().freeze();

            Destroy(gameObject,1.3f);
        }
    }

    IEnumerator Enable()
    {
        yield return null;

        Sprite.enabled = true;

        flashNoise.Play();
    }
}
