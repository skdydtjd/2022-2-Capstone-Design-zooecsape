using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSponer : MonoBehaviour
{
    public GameObject bossEnable;
    public GameObject bossHPEnable;
    public GameObject PlayerLimit;

    bool changeMusic = false;

    // Start is called before the first frame update
    void Start()
    {
        bossEnable.SetActive(false);
        bossHPEnable.SetActive(false);
        PlayerLimit.GetComponent<PlayerLimit>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            bossEnable.SetActive(true);
            bossHPEnable.SetActive(true);
            PlayerLimit.GetComponent<PlayerLimit>().enabled = true;

            if (backgroundMusic.Instance != null && changeMusic == false)
            {
                backgroundMusic.Instance.stage.Stop();
                backgroundMusic.Instance.boss.Play();
                backgroundMusic.Instance.personal.Stop();
                changeMusic = true;
            }
        }
    }
}
