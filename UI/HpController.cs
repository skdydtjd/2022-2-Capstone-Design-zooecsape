using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpController : MonoBehaviour
{
    Slider slHP;
    GameObject pl;
    float plHP;

    // Start is called before the first frame update
    void Start()
    {
        pl = GameObject.Find("Player");
        slHP = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        plHP = pl.GetComponent<Player>().getHP();
        slHP.value = plHP;
    }
}
