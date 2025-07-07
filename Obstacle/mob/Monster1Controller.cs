using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UIElements;

public class Monster1Controller : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    public int nextMove;//���� �ൿ��ǥ�� ������ ����
    GameObject pl;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Invoke("Think", 3); // �ʱ�ȭ �Լ� �ȿ� �־ ����� �� ����(���� 1ȸ) nextMove������ �ʱ�ȭ �ǵ�����
        pl = GameObject.Find("Player");
    }

    private void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y); 
        //nextMove �� 0:���� -1:���� 1:������ ���� �̵� 

        Vector2 front = new Vector2(rigid.position.x + (nextMove*2f),rigid.position.y);

        UnityEngine.Debug.DrawRay(front, Vector3.down*1.5f, new Color(0, 1, 0));

        RaycastHit2D rayHit = Physics2D.Raycast(front, Vector3.down*1.5f);

        if (rayHit.collider == null)
        {
            Turn();
        }
    }


    void Think()
    {//���Ͱ� ������ �����ؼ� �Ǵ� (-1:�����̵� ,1:������ �̵� ,0:����  ���� 3���� �ൿ�� �Ǵ�)

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
