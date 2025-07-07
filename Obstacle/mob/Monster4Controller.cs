using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster4Controller : MonoBehaviour
{
    GameObject pl;
    
    Rigidbody2D rigid;
    public bool isMoved;
    public float spd;

    // Start is called before the first frame update
    void Start()
    {
        pl = GameObject.FindGameObjectWithTag("Player");
        rigid = GetComponent<Rigidbody2D>();
        isMoved = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isMoved)
        {
            StartCoroutine(Move());
            
        }
    }

    IEnumerator Move()
    {
        yield return new WaitForSeconds(1f);
        transform.Translate(Vector3.right * this.spd * Time.deltaTime);
    }
}
