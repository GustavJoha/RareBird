using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public Text YourScore;
    public Text HighscoreText;
    public int Highscore = 0;
    void Start()
    {
        YourScore.text = Pantgubbe.pengar.ToString();
        PlayerPrefs.GetInt("Highscore", Highscore);
        HighscoreText.text = "Highscore:" + Highscore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Pantgubbe.pengar > Highscore)
        {
            Highscore = Pantgubbe.pengar;
            PlayerPrefs.SetInt("Highscore", Highscore);
            PlayerPrefs.GetInt("Highscore", Highscore);
            HighscoreText.text = "Highscore:" + Highscore.ToString();
        }
    }
}
