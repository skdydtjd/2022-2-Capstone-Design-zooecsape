using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCalculator : MonoBehaviour
{
    public Text text;
    int score = 150;

    // BestScore(Ranking)
    int BestScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        BestScore = PlayerPrefs.GetInt("BestScore", 0);
        GetScore();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void GetScore()
    {
        score -= ((int)GameManager.instance.G_Timer)/10;

        if (score > BestScore)
        {
            BestScore = score;
            PlayerPrefs.SetInt("BestScore", BestScore);
            PlayerPrefs.Save();
        }

        SetText();
    }

    void SetText()
    {
        text.text = score + "\n" + "\n" + "BestScore : " + BestScore;
    }
}
