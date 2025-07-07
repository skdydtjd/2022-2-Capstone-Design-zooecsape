using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UIElements;

public class Monster1Controller : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    public int nextMove;//다음 행동지표를 결정할 변수
    GameObject pl;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Invoke("Think", 3); // 초기화 함수 안에 넣어서 실행될 때 마다(최초 1회) nextMove변수가 초기화 되도록함
        pl = GameObject.Find("Player");
    }

    private void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y); 
        //nextMove 에 0:멈춤 -1:왼쪽 1:오른쪽 으로 이동 

        Vector2 front = new Vector2(rigid.position.x + (nextMove*2f),rigid.position.y);

        UnityEngine.Debug.DrawRay(front, Vector3.down*1.5f, new Color(0, 1, 0));

        RaycastHit2D rayHit = Physics2D.Raycast(front, Vector3.down*1.5f);

        if (rayHit.collider == null)
        {
            Turn();
        }
    }


    void Think()
    {//몬스터가 스스로 생각해서 판단 (-1:왼쪽이동 ,1:오른쪽 이동 ,0:멈춤  으로 3가지 행동을 판단)

        if (transform.position.x - pl.transform.position.x < 7f)
        {
            searchPL();
        }
        else
        {
            nextMove = 0;
            anim.SetBool("isWalk", false);
        }

        Invoke("Think", 3); 
    }

    void searchPL()
    {
        if (transform.position.x < pl.transform.position.x)
        {
            nextMove = 1;
            spriteRenderer.flipX = false;
            anim.SetBool("isWalk", true);
        }
        else
        {
            nextMove = -1;
            spriteRenderer.flipX = true;
            anim.SetBool("isWalk", true);
        }
    }  

    void Turn()
    {
        nextMove *= -1;
        spriteRenderer.flipX = nextMove == 1;

        CancelInvoke();
        Invoke("Think", 2);
    }
}
