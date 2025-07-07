using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cartoon1 : MonoBehaviour
{
    public GameObject cartoon1;
    public GameObject cartoon2;

    SpriteRenderer cartoon11;
    SpriteRenderer cartoon22;

    float timerMax = 2f;

    private void Awake()
    {
        cartoon11 = cartoon1.GetComponent<SpriteRenderer>();
        cartoon22 = cartoon2.GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CartoonChange());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SceneChange()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.G_TimerStart = true;
        }

        SceneManager.LoadScene("Stage3");
    }

    IEnumerator CartoonChange()
    {
        yield return new WaitForSeconds(2f);

        float backTime = 0f;
        float backTime2 = 0f;

        float alpha1 = 1f;
        float alpha2 = 0f;

        while (backTime < timerMax)
        {
            backTime += Time.deltaTime;

            alpha1 -= Time.deltaTime;

            if (alpha1 < 0f)
            {
                alpha1 = 0f;
            }

            cartoon11.color = new Color(1, 1, 1, alpha1);

            yield return null;
        }

        if(alpha1 <= 0f)
        {
            while (backTime2 < timerMax)
            {
                backTime2 += Time.deltaTime;
                alpha2 += Time.deltaTime;

                cartoon22.color = new Color(1, 1, 1, alpha2);

                if (alpha2 >= 1f)
                {
                    alpha2 = 1f;

                    yield return new WaitForSeconds(2f);

                    if (GameManager.instance != null)
                    {
                        GameManager.instance.G_TimerStart = true;
                    }

                    SceneManager.LoadScene("Stage3");
                }
                yield return null;
            }
        }
    }
}
