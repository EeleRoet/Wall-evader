using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    static Text scoreText;
    static Text streakText;
    [SerializeField] private ScoreCalcAnimations scoreAnimationScript;

    private static ScoreCalcAnimations staticScoreAnimationScript;
    public static float score;             //current playerscore displayed top-right
    public  static float scoreToAdd;
    private static float streakCount;
    private static float streakMultiplier;  //current streak-value: used to calculate score and displayed top-right
    private static float inclineMargin;     //difference in playeranswer and actual answer: used to calculate score
    private static float baseScore;         //score for perfect anser: used to calculate score
    private static float timeLeft;          //amount of time left when answer was given: used to calculate score and displayed middle left

    // Start is called before the first frame update
    public void Start()
    {
        staticScoreAnimationScript = scoreAnimationScript;
        timeLeft = 1;
        baseScore = 10;
        score = 0;
        streakCount = 0;
        streakMultiplier = 1;
        scoreText = GetChildComponentByName<Text>("score");
        scoreText.text = "0";
        streakText = GetChildComponentByName<Text>("streak");
        Debug.Log(streakText.text);
        streakText.text = "streak: " + streakMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
        streakText.text = "streak: " + (streakMultiplier);
    }

    public static void AddTimerScore(int time)
    {
        if(time == 0)
        {
            time++;
        }

        timeLeft = time;
        Debug.Log(timeLeft);
        
    }

    public static void AddMarginScore(float wallIncline, float inputIncline)
    {
        
        float tempScore;
        float tempStreakMultiplier;

        inputIncline /= 10;//reverts input value to decimal float

        MarginAnimation.StartAnimation(wallIncline - inputIncline);//start animation for margin text on screen

        inclineMargin = Mathf.Abs(wallIncline - inputIncline);//sets inclineMargin to the difference of the parameters
        inclineMargin *= 10;//converts inlcine margin to an integer
        BumpStreak(inclineMargin);

        inclineMargin++;//adds 1 to avoid deviding by 0
        tempStreakMultiplier = streakMultiplier > 0 ? streakMultiplier : 1;
        tempScore = (float)System.Math.Round( timeLeft * (baseScore / inclineMargin) * tempStreakMultiplier, 1);
        staticScoreAnimationScript.BaseScoreTriggerAnimations( (float)System.Math.Round( baseScore / inclineMargin, 1) , tempScore);
        scoreToAdd = tempScore;

    }


    private static void BumpStreak(float Margin)
    {
        if (Margin == 0)
        {
           if(++streakCount >= streakMultiplier)
           {
                streakMultiplier++;
                streakCount = 0;
           }
        }
        else
        {
            streakCount = 0;
            streakMultiplier = 1;
        }

    }

    public static void AddScore()
    {
        score += scoreToAdd;
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
