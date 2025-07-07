using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Monster;

public class BBShot : MonoBehaviour
{
    GameObject pl;
    Transform direction;
    Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        pl = GameObject.Find("Player");
        direction = this.transform.parent;
        rigid = transform.GetComponent<Rigidbody2D>();

        Debug.Log(direction.GetComponent<Monster2Controller>()._state);

        if(direction.GetComponent<Monster2Controller>()._state==Monster.Monster2Controller.state.push)
        {
            push();
        }

        
    }

    // Update is called once per frame
    void Update()
    {

        if (direction.GetComponent<Monster2Controller>()._state == Monster.Monster2Controller.state.shot)
        {
            shot();
        }
        Destroy(gameObject, 5f);
    }

    void shot()
    {
        if (direction.GetComponent<Monster2Controller>().nextMove == 1)
        {
            transform.Translate(Vector2.right * 0.05f);
            
        }
        else if (direction.GetComponent<Monster2Controller>().nextMove == -1)
        {
            transform.Translate(Vector2.right * -0.05f);
        }
    }

    void push()
    {
        rigid.gravityScale = 1;
        if (direction.GetComponent<Monster2Controller>().nextMove == 1)
        {
            rigid.AddForce(new Vector2(10f, 1.5f),ForceMode2D.Impulse);
        }
        else if (direction.GetComponent<Monster2Controller>().nextMove == -1)
        {
            rigid.AddForce(new Vector2(-10f, 1.5f), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject != direction.gameObject)
        {
            Destroy(gameObject);
        }
        
    }
}
