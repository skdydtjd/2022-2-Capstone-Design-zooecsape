using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BossSeaLion : MonoBehaviour
{
    public Animator anim;

    public AudioSource SeaLionNoise;

    public AudioSource Clear;

    public AudioSource MakeItems;

    public Vector3 point1;
    public Vector3 point2;
    public Vector3 point3;

    public GameObject fish;
    public GameObject ice;
    public GameObject HPItem;

    float timerMax = 1.5f;
    public float speed;

    void Start()
    {
        StartCoroutine(Thick());
    }

    void Update()
    {

    }

    IEnumerator Thick()
    {
        anim.SetBool("doJump", false);

        yield return new WaitForSeconds(5f);

        // 물고기 점수에 따른 보스 클리어 처리
        if (GameManager.instance != null)
        {
            if (GameManager.instance.fishcount == 15)
            {
                StopAllCoroutines();
                anim.SetTrigger("doDie");

                Clear.Play();

                yield return new WaitForSeconds(1.5f);

                gameObject.SetActive(false);
            }
        }

        int RandomAction = Random.Range(0, 5);

        switch(RandomAction)
        {
            case 0:
            case 1:
            case 2:
                StartCoroutine(Moving());
                break;
            case 3:
            case 4:
                StartCoroutine(ThrowFish());
                break;
        }
    }

    // 움직이기 패턴
    IEnumerator Moving()
    {
        anim.SetBool("doJump", true);

        yield return new WaitForSeconds(0.3f);

        float timeCurrent = 0.0f;
        float backTime = 0.0f;

        SeaLionNoise.Play();

        while (timeCurrent < timerMax)
        {
            timeCurrent += Time.deltaTime;

            float t = timeCurrent / timerMax*speed;

            Vector3 ab = Vector3.Lerp(point1, point2, t);
            Vector3 bc = Vector3.Lerp(point2, point3, t);

            transform.position
                = Vector3.Lerp(ab,bc,t);

            yield return null;
        }

        while (backTime < timerMax)
        {
            backTime += Time.deltaTime;

            transform.position
                = Vector3.Lerp(point3, point1, backTime/timerMax*speed);

            yield return null;
        }

        StartCoroutine(Thick());
    }

    // 물고기 패턴
    IEnumerator ThrowFish()
    {
        GameObject instantFish;

        Stage3Fish stage3Fish;
        Stage3Ice stage3ice;
        Stage3HPItem stage3HPitem;

        float[] fishYpos = new float[3];

        fishYpos[0] = -3.5f;
        fishYpos[1] = 0;
        fishYpos[2] = 3.5f;

        MakeItems.Play();

        for (int i = 0; i < 8; i++)
        {
            int randMake = Random.Range(0, 11);
            int randY = Random.Range(0, 3);

            if (randMake < 5)
            {
                instantFish = Instantiate(ice, new Vector2(12f, fishYpos[randY]), Quaternion.identity);
                stage3ice = instantFish.GetComponent<Stage3Ice>();
            }
            else if (5 <= randMake && randMake < 8)
            {
                instantFish = Instantiate(fish, new Vector2(12f, fishYpos[randY]), Quaternion.identity);
                stage3Fish = instantFish.GetComponent<Stage3Fish>();
            }
            else if (randMake >= 8)
            {
                instantFish = Instantiate(HPItem, new Vector2(12f, fishYpos[randY]), Quaternion.identity);
                stage3HPitem = instantFish.GetComponent<Stage3HPItem>();
            }

            yield return new WaitForSeconds(1f);
        }
        StartCoroutine(Thick());
    }
}
