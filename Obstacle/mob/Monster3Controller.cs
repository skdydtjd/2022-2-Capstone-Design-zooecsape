using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster3Controller : MonoBehaviour
{

    public Transform pl;
    public GameObject stone;
    bool existStone;
    public SpriteRenderer spriteRenderer;

    AudioSource crow;

    private void Start()
    {
        existStone = true;
        crow = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Ÿ�ٰ� �ڽ��� �Ÿ��� Ȯ��
        float distance = transform.position.x - pl.position.x;

        // ���� ������(��Ÿ��)�� 0�� ��, �þ� �����ȿ� ���� ��
        if (distance < 15f && distance > 1f && existStone)
        {
            crow.Play();
            FaceTarget(); // Ÿ�� �ٶ󺸱�
            this.spriteRenderer.flipX = true;
            MoveToTarget();
        }

        if (distance <= 1f && existStone)
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            stone.GetComponent<Rigidbody2D>().gravityScale = 3f;
            existStone = false;
        }


    }

    void MoveToTarget()
    {
        float dir = pl.position.x - transform.position.x;
        float dirY = pl.position.y + 5f - transform.position.y;
        dir = (dir < 0) ? -1 : 1;
        transform.Translate(new Vector2(dir, dirY) * 5f * Time.deltaTime); //�ӵ� ���� ����
    }

    void FaceTarget()
    {
        if (pl.position.x - transform.position.x < 0) // Ÿ���� ���ʿ� ���� ��
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else // Ÿ���� �����ʿ� ���� ��
        {
            transform.localScale = new Vector3(1, 1, 1);            
        }
    }

}
