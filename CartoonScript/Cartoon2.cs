using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cartoon2 : MonoBehaviour
{
    public GameObject cartoon1;

    SpriteRenderer cartoon11;

    float timerMax = 2f;

    private void Awake()
    {
        cartoon11 = cartoon1.GetComponent<SpriteRenderer>();
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
        SceneManager.LoadScene("Ending");
    }

    IEnumerator CartoonChange()
    {
        yield return new WaitForSeconds(2f);

        float backTime = 0f;

        float alpha1 = 1f;

        while (backTime < timerMax)
        {
            backTime += Time.deltaTime;

            alpha1 -= Time.deltaTime;

            if (alpha1 <= 0f)
            {
                alpha1 = 0f;

                yield return new WaitForSeconds(2f);

                SceneManager.LoadScene("Ending");
            }

            cartoon11.color = new Color(1, 1, 1, alpha1);

            yield return null;
        }
    }
}
