using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageScoreText : MonoBehaviour
{
    public Text scoreText;
    int score;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        score = (int)GameManager.instance.G_Timer;

        scoreText.text = " Your Time - " + score;
    }
}
