using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneEffect : MonoBehaviour
{
    public Animator animator;
    public GameObject PlayerHP;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (BossTimer.Instance != null)
        {
            if (BossTimer.Instance.Bosstime == 0)
            {
                StartCoroutine(FadeOut());
            }
        }
    }

    IEnumerator FadeOut()
    {
        if (backgroundMusic.Instance != null)
        {
            backgroundMusic.Instance.boss.Stop();
        }

        yield return new WaitForSeconds(2f);

        PlayerHP.SetActive(false);
        animator.SetTrigger("StartFadeOut");

        yield return new WaitForSeconds(1.3f);

        if(GameManager.instance != null)
        {
            GameManager.instance.G_TimerStart = false;
        }

        SceneManager.LoadScene("Stage1,2 Cartoon");
    }
}
