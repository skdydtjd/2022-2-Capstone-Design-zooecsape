using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLimit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.x < 0.02f)
            pos.x = 0.02f; 

        if (pos.x > 0.98f) 
            pos.x = 0.98f;

        if (pos.y > 0.98f) 
            pos.y = 0.98f; 

        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}
