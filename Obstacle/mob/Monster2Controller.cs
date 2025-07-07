using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UIElements;

namespace Monster
{

    public class Monster2Controller : MonoBehaviour
    {
        Rigidbody2D rigid;
        public int nextMove;//다음 행동지표를 결정할 변수
        public float spd;

        GameObject pl;
        public GameObject BBPrefab;

        public enum state { shot, push };
        public state _state;

        AudioSource laugh;

        // Start is called before the first frame update
        private void Awake()
        {
            rigid = GetComponent<Rigidbody2D>();
            laugh = GetComponent<AudioSource>();

            Invoke("Think", 3); // 초기화 함수 안에 넣어서 실행될 때 마다(최초 1회) nextMove변수가 초기화 되도록함
            spd = 3f;
            pl = GameObject.Find("Player");
        }

        private void Start()
        {
            Vector2 plPos = pl.transform.position;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            //rigid.velocity = new Vector2(nextMove, rigid.velocity.y) * spd; //nextMove 에 0:멈춤 -1:왼쪽 1:오른쪽 으로 이동 
        }


        void Think()
        {//몬스터가 스스로 생각해서 판단 (-1:왼쪽이동 ,1:오른쪽 이동 ,0:멈춤  으로 3가지 행동을 판단)

            //Random.Range : 최소<= 난수 <최대 /범위의 랜덤 수를 생성(최대는 제외이므로 주의해야함)

            if (Mathf.Abs(transform.position.x - pl.transform.position.x) < 10f)
            {
                laugh.Play();
                searchPL();
            }
            else
            {
                nextMove = 0;
            }


            Invoke("Think", 3);
        }

        void searchPL()
        {
            if (transform.position.x < pl.transform.position.x)
            {
                nextMove = 1;
                GameObject BB = Instantiate(BBPrefab);
                BB.transform.parent = this.transform;
                BB.transform.position = new Vector2(this.transform.position.x + 1f, this.transform.position.y);
            }
            else
            {
                nextMove = -1;
                GameObject BB = Instantiate(BBPrefab);
                BB.transform.parent = this.transform;
                BB.transform.position = new Vector2(this.transform.position.x - 1f, this.transform.position.y);
            }

        }

    }
}