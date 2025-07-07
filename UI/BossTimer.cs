using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossTimer : MonoBehaviour
{
    static BossTimer _instance;

    public static BossTimer Instance
    {
        get { return _instance; }
    }

    public float Bosstime;
    public float BossTimerDownSpeed;

    public Image HPBar;
    public Text HPText;

    private void Awake()
    {
        if(Instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Bosstime = Bosstime - Time.deltaTime;

        if (Bosstime < 0)
        {
            Bosstime = 0f;
            StartCoroutine(DelayforClearText());
        }
        else
        {
            HPText.text = $"{Bosstime:N2}";
        }

        HPBar.fillAmount = Bosstime / BossTimerDownSpeed;
    }

    IEnumerator DelayforClearText()
    {
        yield return new WaitForSeconds(1.5f);

        HPText.text = "CLEAR";
    }
}
