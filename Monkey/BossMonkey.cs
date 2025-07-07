using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMonkey : MonoBehaviour
{

    public Animator anim;

    public List<GameObject> Fruits;
    public GameObject Banana;
    public GameObject ShoutingSound;

    // 페이즈 1의 소리 개수
    public int ShoutingCount1;

    // 페이즈 2의 소리 개수
    public int ShoutingCount2;

    public int ShoutingSpeed;

    public AudioSource throwObject;
    public AudioSource shoutnoise;
    public AudioSource Clear;

    private void Awake()
    {
        StartCoroutine(BeforeEnabled());
    }

    void Start()
    {

    }

    void Update()
    {

    }

    IEnumerator BeforeEnabled()
    {
        yield return new WaitForSeconds(2f);

        StartCoroutine(Thick());
    }

    IEnumerator Thick()
    {
        yield return new WaitForSeconds(0.7f);

        // 시간 경과에 따른 보스 클리어 처리
        if (BossTimer.Instance != null)
        {
            if (BossTimer.Instance.Bosstime < 1.5f)
            {
                StopAllCoroutines();
                anim.SetTrigger("doDie");

                Clear.Play();

                yield return new WaitForSeconds(0.5f);

                gameObject.SetActive(false);
            }
        }

        int randAction = Random.Range(0, 7);

        switch (randAction)
        {
            case 0:
            case 1:
            case 2:
                StartCoroutine(ThrowFruits());
                break;
            case 3:
            case 4:
            case 5:
                StartCoroutine(ThrowBanana());
                break;
            case 6:
            case 7:
                StartCoroutine(Shounting());
                break;
        }
    }

    // 과일 던지기 패턴
    IEnumerator ThrowFruits()
    {
        if (BossTimer.Instance != null)
        {
            if (BossTimer.Instance.Bosstime <= 30)
            {
                StartCoroutine(ThrowFruitsH());
            }
            else
            {
                anim.SetTrigger("doThrowFruits");

                // 각각 다른 과일들을 불러오기위한 int 배열
                int[] fruitsinstance = new int[5];

                for (int i = 0; i < fruitsinstance.Length; i++)
                {
                    fruitsinstance[i] = Random.Range(0, Fruits.Count);
                }

                throwObject.Play();

                yield return new WaitForSeconds(0.3f);

                // 각각 다른 프리팹 생성
                GameObject[] instantFruit = new GameObject[5];
                ThrowFruitPattern[] throwFruit = new ThrowFruitPattern[5];

                for(int i = 0; i < 5; i++)
                {
                    instantFruit[i] = Instantiate(Fruits[fruitsinstance[i]], new Vector2(transform.position.x-2, transform.position.y+2), 
                        Quaternion.identity);
                    throwFruit[i] = instantFruit[i].GetComponent<ThrowFruitPattern>();
                }

                yield return new WaitForSeconds(2f);

                StartCoroutine(Thick());
            }
        }
    }

    IEnumerator ThrowFruitsH()
    {
        anim.SetTrigger("doThrowFruitsH");

        // 각각 다른 과일들을 불러오기위한 int 배열
        int[] fruitsinstance = new int[8];

        for (int i = 0; i < fruitsinstance.Length; i++)
        {
            fruitsinstance[i] = Random.Range(0, Fruits.Count);
        }

        throwObject.Play();

        yield return new WaitForSeconds(0.3f);

        // 각각 다른 프리팹 생성
        GameObject[] instantFruit = new GameObject[8];
        ThrowFruitPattern[] throwFruit = new ThrowFruitPattern[8];

        for (int i = 0; i < 8; i++)
        {
            instantFruit[i] = Instantiate(Fruits[fruitsinstance[i]], new Vector2(transform.position.x-2, transform.position.y + 2)
                , Quaternion.identity);
            throwFruit[i] = instantFruit[i].GetComponent<ThrowFruitPattern>();
        }

        yield return new WaitForSeconds(2f);

        StartCoroutine(Thick());
    }

    // 바나나 던지기 패턴
    IEnumerator ThrowBanana()
    {
        if (BossTimer.Instance != null)
        {
            if (BossTimer.Instance.Bosstime <= 30)
            {
                StartCoroutine(ThrowBananaH());
            }
            else
            {
                anim.SetTrigger("doThrowBanana");

                throwObject.Play();

                for (int i = 0; i < 3; i++)
                {
                    GameObject instantBanana1 = Instantiate(Banana, new Vector2(218, -2.2f), Quaternion.identity);
                    ThrowBananaPattern throwBanana = instantBanana1.GetComponent<ThrowBananaPattern>();

                    yield return new WaitForSeconds(0.3f);
                }

                yield return new WaitForSeconds(0.2f);

                for (int i = 0; i < 3; i++)
                {
                    GameObject instantBanana1 = Instantiate(Banana, new Vector2(218, 1.3f), Quaternion.identity);
                    ThrowBananaPattern throwBanana = instantBanana1.GetComponent<ThrowBananaPattern>();

                    yield return new WaitForSeconds(0.3f);
                }

                yield return new WaitForSeconds(0.2f);

                for (int i = 0; i < 3; i++)
                {
                    GameObject instantBanana1 = Instantiate(Banana, new Vector2(218, 4.4f), Quaternion.identity);
                    ThrowBananaPattern throwBanana = instantBanana1.GetComponent<ThrowBananaPattern>();

                    yield return new WaitForSeconds(0.3f);
                }

                yield return new WaitForSeconds(1f);

                StartCoroutine(Thick());
            }
        }
    }

    IEnumerator ThrowBananaH()
    {
        anim.SetTrigger("doThrowBananaH");

        throwObject.Play();

        for (int i = 0; i < 5; i++)
        {
            GameObject instantBanana1 = Instantiate(Banana, new Vector2(218, -2.2f), Quaternion.identity);
            ThrowBananaPattern throwBanana = instantBanana1.GetComponent<ThrowBananaPattern>();

            yield return new WaitForSeconds(0.3f);
        }

        yield return new WaitForSeconds(0.2f);

        for (int i = 0; i < 5; i++)
        {
            GameObject instantBanana1 = Instantiate(Banana, new Vector2(218, 1.3f), Quaternion.identity);
            ThrowBananaPattern throwBanana = instantBanana1.GetComponent<ThrowBananaPattern>();

            yield return new WaitForSeconds(0.3f);
        }

        yield return new WaitForSeconds(0.2f);

        for (int i = 0; i < 5; i++)
        {
            GameObject instantBanana1 = Instantiate(Banana, new Vector2(218, 4.4f), Quaternion.identity);
            ThrowBananaPattern throwBanana = instantBanana1.GetComponent<ThrowBananaPattern>();

            yield return new WaitForSeconds(0.3f);
        }

        yield return new WaitForSeconds(0.2f);

        StartCoroutine(Thick());
    }

    // 소리치기 패턴
    IEnumerator Shounting()
    {
        if (BossTimer.Instance != null)
        {
            if (BossTimer.Instance.Bosstime <= 30)
            {
                StartCoroutine(ShountingH());
            }
            else
            {
                anim.SetTrigger("doShouting");

                shoutnoise.Play();

                for (int i = 0; i < ShoutingCount1; i++)
                {
                    GameObject instantShounting = Instantiate(ShoutingSound, new Vector2(transform.position.x, transform.position.y + 2), Quaternion.identity);
                    ShoutingPattern shout = instantShounting.GetComponent<ShoutingPattern>();

                    shout.rb.AddForce(new Vector2(-(ShoutingSpeed * Mathf.Cos(Mathf.PI / 3 * i / 5)),
                        -(ShoutingSpeed * Mathf.Sin(Mathf.PI / 3 * i / 5))), ForceMode2D.Impulse);

                    shout.transform.Rotate(new Vector3(0f, 0f, -(30 * i / ShoutingCount1 - 30)));
                }

                yield return new WaitForSeconds(3.5f);

                StartCoroutine(Thick());
            }
        }
    }

    IEnumerator ShountingH()
    {
        anim.SetTrigger("doShoutingH");

        shoutnoise.Play();

        yield return new WaitForSeconds(1f);

        for (int i = 0; i < ShoutingCount1; i++)
        {
            GameObject instantShounting = Instantiate(ShoutingSound, new Vector2(transform.position.x, transform.position.y + 2), Quaternion.identity);
            ShoutingPattern shout = instantShounting.GetComponent<ShoutingPattern>();

            shout.rb.AddForce(new Vector2(-(ShoutingSpeed * Mathf.Cos(Mathf.PI / 3 * i / 5)),
                -(ShoutingSpeed * Mathf.Sin(Mathf.PI / 3 * i / 5))), ForceMode2D.Impulse);

            shout.transform.Rotate(new Vector3(0f, 0f, -(30 * i / ShoutingCount1 - 30)));
        }

        yield return new WaitForSeconds(1.5f);

        for (int i = 0; i < ShoutingCount2; i++)
        {
            GameObject instantShounting = Instantiate(ShoutingSound, new Vector2(transform.position.x, transform.position.y + 3), Quaternion.identity);
            ShoutingPattern shout = instantShounting.GetComponent<ShoutingPattern>();

            shout.rb.AddForce(new Vector2(-(ShoutingSpeed * Mathf.Cos(Mathf.PI / 3 * i / 5)),
                -(ShoutingSpeed * Mathf.Sin(Mathf.PI / 3 * i / 5))), ForceMode2D.Impulse);

            shout.transform.Rotate(new Vector3(0f, 0f, -(30 * i / ShoutingCount1 - 30)));
        }

        yield return new WaitForSeconds(1.5f);

        StartCoroutine(Thick());
    }
}
