using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimerController : MonoBehaviour
{
    Slider slTimer;
    float fSliderBarTime;

    void Start()
    {
        slTimer = GetComponent<Slider>();
    }

    void Update()
    {
        if (slTimer.value > 0.0f)
        {
            // �ð��� ������ ��ŭ slider Value ������ �մϴ�.
            slTimer.value -= Time.deltaTime;
        }
        else
        {
            GameManager.instance.gameOver();
        }
    }
}
