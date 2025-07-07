using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stoneController : MonoBehaviour
{
    Transform pa;
    
    // Start is called before the first frame update
    void Start()
    {
        pa = this.transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }


}
