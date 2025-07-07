using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcaCollid : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(collidOn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator collidOn()
    {
        yield return new WaitForSeconds(3f);
        this.GetComponent<CircleCollider2D>().enabled = true;
    }
}
