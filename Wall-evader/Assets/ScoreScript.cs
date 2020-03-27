using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static int score;
    static Text scoreText;
    static Text highscoreText;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText = GetChildComponentByName<Text>("score");
        highscoreText = GetChildComponentByName<Text>("highscore");
        highscoreText.text = "highscore: " + PlayerPrefs.GetInt("highscore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "score: " + score;
       
    }

    public static void AddScore()
    {
        score++;
        if ( score > PlayerPrefs.GetInt("highscore", 0))
        {
            PlayerPrefs.SetInt("highscore", score);
            highscoreText.text = "highscore: " + score;
        }
    }

    //method from stackoverflow answer by: markroth8 at: 
    //https://forum.unity.com/threads/get-ui-components-by-name-with-getcomponent.408004/
    private T GetChildComponentByName<T>(string name) where T : Component
    {
        foreach (T component in GetComponentsInChildren<T>(true))
        {
            if (component.gameObject.name == name)
            {
                return component;
            }
        }
        return null;
    }
}
