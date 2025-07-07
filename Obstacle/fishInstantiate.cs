using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Obstacle
{
    public class fishInstantiate : MonoBehaviour
    {
        public SpriteRenderer Sprite;
        public GameObject fishPrefeb;
        public GameObject fishPoint;
        GameObject pl;
        // Start is called before the first frame update
        void Start()
        {
            pl = GameObject.FindGameObjectWithTag("Player");
            Sprite = GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            Sprite.enabled = false;

        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                GameObject fish = Instantiate(fishPrefeb);
                fish.transform.position = new Vector2(fishPoint.transform.position.x, fishPoint.transform.position.y);
                Destroy(gameObject);
            }
        }
    }

}

