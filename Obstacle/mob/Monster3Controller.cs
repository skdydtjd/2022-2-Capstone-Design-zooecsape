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
        // 타겟과 자신의 거리를 확인
        float distance = transform.position.x - pl.position.x;

        // 공격 딜레이(쿨타임)가 0일 때, 시야 범위안에 들어올 때
        if (distance < 15f && distance > 1f && existStone)
        {
            crow.Play();
            FaceTarget(); // 타겟 바라보기
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
        transform.Translate(new Vector2(dir, dirY) * 5f * Time.deltaTime); //속도 조절 가능
    }

    void FaceTarget()
    {
        if (pl.position.x - transform.position.x < 0) // 타겟이 왼쪽에 있을 때
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else // 타겟이 오른쪽에 있을 때
        {
            transform.localScale = new Vector3(1, 1, 1);            
        }
    }

}
