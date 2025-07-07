using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCat : MonoBehaviour
{
    public Animator anim;

    public GameObject player;
    public List<GameObject> scratchEffect;
    public GameObject Cup;

    public GameObject waterflow;

    public AudioSource movingSound;
    public AudioSource moving;

    public AudioSource ScratchCatSound;
    public AudioSource scratchSound;

    public AudioSource ThrowCupSound;

    public AudioSource waterCatSound;
    public AudioSource water;

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
        yield return new WaitForSeconds(2f);

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

            // 물 차오르기
            if (BossTimer.Instance.Bosstime < 26f && BossTimer.Instance.Bosstime > 20f)
            {
                Transform original = waterflow.transform;

                StartCoroutine(Crying(original.position, original.position + new Vector3(0, 5.5f, 0), 3f));
            }
        }

        int randAction = Random.Range(0, 7);

        switch (randAction)
        {
            case 0:
            case 1:
            case 2:
                StartCoroutine(ThrowCups());
                break;
            case 3:
            case 4:
            case 5:
                StartCoroutine(Scratch());
                break;
            case 6:
            case 7:
                StartCoroutine(Moving());
                break;
        }
    }

    // 움직이기 패턴(5초)
    IEnumerator Moving()
    {
        anim.SetBool("doMoving", true);

        movingSound.Play();

        yield return new WaitForSeconds(1f);

        for (int i = 0; i < 5; i++)
        {
            transform.position = 
                new Vector2(player.transform.position.x+2.5f, player.transform.position.y+0.5f);

            moving.Play();

            yield return new WaitForSeconds(0.4f);
        }

        yield return new WaitForSeconds(1f);

        transform.position = new Vector2(221.5f, 13.6f);
        anim.SetBool("doMoving", false);

        yield return new WaitForSeconds(1f);

        StartCoroutine(Thick());
    }

    // 할퀴기 패턴(5.1초)
    IEnumerator Scratch()
    {
        ScratchCatSound.Play();

        yield return new WaitForSeconds(0.5f);

        int Scratch = Random.Range(0, scratchEffect.Count);

        for (int i = 0; i < 13; i++)
        {
            scratchSound.Play();

            GameObject instantScratch = Instantiate(scratchEffect[Scratch], new Vector2(Random.Range(193f,219f),Random.Range(0.5f,13f)), Quaternion.Euler(0,0,Random.Range(0f,350f)));
            ScratchPattern scratchstart = instantScratch.GetComponent<ScratchPattern>();

            yield return new WaitForSeconds(0.2f);
        }

        yield return new WaitForSeconds(2f);

        StartCoroutine(Thick());
    }

    // 컵 깨뜨리기 패턴(4.4초)
    IEnumerator ThrowCups()
    {
        ThrowCupSound.Play();

        for (int i = 0; i < 12; i++)
        {
            GameObject instantCups = Instantiate(Cup, new Vector2(Random.Range(193f,219f),20),Quaternion.Euler(0,0,Random.Range(0f,360f)));
            BreakCupPattern cups = instantCups.GetComponent<BreakCupPattern>();

            yield return new WaitForSeconds(0.2f);
        }

        yield return new WaitForSeconds(2f);

        StartCoroutine(Thick());
    }

    // 물 차오르기 패턴
    IEnumerator Crying(Vector3 transform, Vector3 target, float timeToMove)
    {
        waterCatSound.Play();

        yield return new WaitForSeconds(2f);

        water.Play();

        float elapsedTime = 0.0f;

        while (elapsedTime < timeToMove)
        {
            elapsedTime += Time.deltaTime;

            waterflow.transform.position
                = Vector3.Lerp(transform, target, elapsedTime / timeToMove);

            yield return null;
        }

        yield return new WaitForSeconds(2f);

        StartCoroutine(Thick());
    }
}
