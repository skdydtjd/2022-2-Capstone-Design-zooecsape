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
        public int nextMove;//���� �ൿ��ǥ�� ������ ����
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

            Invoke("Think", 3); // �ʱ�ȭ �Լ� �ȿ� �־ ����� �� ����(���� 1ȸ) nextMove������ �ʱ�ȭ �ǵ�����
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
            //rigid.velocity = new Vector2(nextMove, rigid.velocity.y) * spd; //nextMove �� 0:���� -1:���� 1:������ ���� �̵� 
        }


        void Think()
        {//���Ͱ� ������ �����ؼ� �Ǵ� (-1:�����̵� ,1:������ �̵� ,0:����  ���� 3���� �ൿ�� �Ǵ�)

            //Random.Range : �ּ�<= ���� <�ִ� /������ ���� ���� ����(�ִ�� �����̹Ƿ� �����ؾ���)

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