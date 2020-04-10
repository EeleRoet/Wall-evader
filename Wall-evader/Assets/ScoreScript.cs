using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    
    static Text scoreText;
    static Text streakText;

    private static float score;             //current playerscore displayed top-right
    private static float streakMultiplier;  //current streak-value: used to calculate score and displayed top-right
    private static float inclineMargin;     //difference in playeranswer and actual answer: used to calculate score
    private static float baseScore;         //score for perfect anser: used to calculate score
    private static float timeLeft;          //amount of time left when answer was given: used to calculate score and displayed middle left

    // Start is called before the first frame update
    public void Start()
    {
        timeLeft = 1;
        baseScore = 10;
        score = 0;
        streakMultiplier = 1;
        scoreText = GetChildComponentByName<Text>("score");
        scoreText.text = "0";
        streakText = GetChildComponentByName<Text>("streak");
        streakText.text = "streak: " + streakMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
        streakText.text = "streak: " + (streakMultiplier - 1);
    }

    public static void AddTimerScore(int time)
    {
        if(time == 0)
        {
            time++;
        }

        timeLeft = time;
    }

    public static void AddMarginScore(float wallIncline, float inputIncline)
    {
        float tempScore;

        inputIncline /= 10;//reverts input value to decimal float
        inclineMargin = Mathf.Abs(wallIncline - inputIncline);//sets inclineMargin to the difference of the parameters
        inclineMargin *= 10;//converts inlcine margin to an integer

        if ( inclineMargin == 0)
        {
            streakMultiplier++;
        }
        else
        {
            streakMultiplier = 1;
        }
        inclineMargin++;//adds 1 to avoid deviding by 0
        tempScore = timeLeft * (baseScore / inclineMargin) * streakMultiplier;
        score += tempScore;

        checkHigherScore();
    }

    private static void checkHigherScore()
    {
        if (score > PlayerPrefs.GetFloat("highscore", 0))
        {
            PlayerPrefs.SetFloat("highscore", score);
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
