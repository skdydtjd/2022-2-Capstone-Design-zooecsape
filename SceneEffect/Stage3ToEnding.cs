using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage3ToEnding : MonoBehaviour
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
        if (GameManager.instance != null)
        {
            if (GameManager.instance.fishcount == 15f)
            {
                StartCoroutine(FadeOut());
            }
        }
    }

    IEnumerator FadeOut()
    {
        if (backgroundMusic.Instance != null)
        {
            backgroundMusic.Instance.stage.Stop();
            backgroundMusic.Instance.personal.Stop();
        }

        yield return new WaitForSeconds(2f);

        PlayerHP.SetActive(false);
        animator.SetTrigger("StartFadeOut");

        yield return new WaitForSeconds(1.3f);

        if (GameManager.instance != null)
        {
            GameManager.instance.G_TimerStart = false;
        }

        SceneManager.LoadScene("Stage3,Ending Cartoon");
    }
}
