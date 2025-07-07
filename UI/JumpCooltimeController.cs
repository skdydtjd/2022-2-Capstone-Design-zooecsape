using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpCooltimeController : MonoBehaviour
{
    //Slider slCooltime;
    GameObject pl;
    int startCount = 0;

    private void Awake()
    {
        pl = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);

        if (pl.GetComponent<Player>().isSliding)
        {
            GetComponent<Image>().color = new Color(1, 1, 1, 1);
            //StartCoroutine(color());
        }

    }
}
