using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCalcAnimations : MonoBehaviour
{
    private Text timerMultiplierText;//needs to be same font as actual timer
    [SerializeField] private Transform timerMultiplierTextAnimationStart;
    [SerializeField] private Transform timerMultiplierTextAnimationEnd;

    private Text baseScoreText;//needs to be same font as timerMultiplierText
    [SerializeField] private Transform baseScoreTextAnimationStart;
    [SerializeField] private Transform baseScoreTextAnimationEnd;

    private Text finalScoreText;//needs to be same font as actualscore
    [SerializeField] private Transform finalScoreTextAnimationStart;
    [SerializeField] private Transform finalScoreTextAnimationEnd;
    private float finalScore;

    private Text streakMultiplierText;//needs to be same font as timerMultiplierText
    [SerializeField] private Transform streakMultiplierTextAnimationStart;
    [SerializeField] private Transform streakMultiplierTextAnimationEnd;
    [SerializeField] private Text actualStreakText;

    private float timerTriggerAnimationLength;
    private float baseScoreTriggerAnimationLength;
    private float addScoreAnimationLength;
   // private float textFadeTime;
    private float addFinalScoreAnimationLength;

    // Start is called before the first frame update
    void Start()
    {
        timerTriggerAnimationLength = 1f;
        baseScoreTriggerAnimationLength = 1f;
        addScoreAnimationLength = 0.3f;
       // textFadeTime = 0.5f;
        addFinalScoreAnimationLength = 1f;
        timerMultiplierText = GetChildComponentByName<Text>("TimerMultiplierText");
        baseScoreText = GetChildComponentByName<Text>("BaseScoreText");
        streakMultiplierText = GetChildComponentByName<Text>("StreakMultiplierText");
        finalScoreText = GetChildComponentByName<Text>("FinalScoreText");
        ResetText();
        ResetFinalScoreText();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TimerTriggerAnimations(int timeLeft)
    {

        //timer text en streak text krijgen goede waardes, en bewegen daarna naar de goede plek.

        timerMultiplierText.gameObject.SetActive(true);
        timerMultiplierText.text = timeLeft.ToString() + " *";
        LeanTween.move(timerMultiplierText.gameObject, timerMultiplierTextAnimationEnd.position, 1).setEase(LeanTweenType.easeOutQuart);
        LeanTween.scale(timerMultiplierText.gameObject, new Vector3(1.5f, 1.5f, 1.5f), timerTriggerAnimationLength);

        streakMultiplierText.gameObject.SetActive(true);
        streakMultiplierText.text = "* " + actualStreakText.text.Split(' ')[1];
        LeanTween.move(streakMultiplierText.gameObject, streakMultiplierTextAnimationEnd.position, 1).setEase(LeanTweenType.easeOutQuart);
        LeanTween.scale(streakMultiplierText.gameObject, new Vector3(1.5f, 1.5f, 1.5f), timerTriggerAnimationLength);

        
      
    }
    

    public void BaseScoreTriggerAnimations(float score, float finalScore)
    {
        //base score text krijgt de goede waarde, en beweegt daarna naar de goede plek.
        //alle 3 de texts komen samen en gaan dan weg, de final score text krijgt de goede waarde en beweegt dan naar de goede plek.
        //de final score text gaat weg en de score wordt geupdate.
        this.finalScore = finalScore;
        baseScoreText.gameObject.SetActive(true);
        baseScoreText.text = score.ToString();
        LeanTween.move(baseScoreText.gameObject, baseScoreTextAnimationEnd.position, baseScoreTriggerAnimationLength).setOnComplete(AddScoresAnimation);
        LeanTween.scale(baseScoreText.gameObject, new Vector3(1.5f, 1.5f, 1.5f), baseScoreTriggerAnimationLength);
    }

    private void AddScoresAnimation()
    {
        timerMultiplierText.text = timerMultiplierText.text.Split(' ')[0];
        LeanTween.move(timerMultiplierText.gameObject, baseScoreTextAnimationEnd, addScoreAnimationLength).setEase(LeanTweenType.easeOutQuart);
        // LeanTween.alpha(timerMultiplierText.gameObject, 0f, 1f);
        streakMultiplierText.text = streakMultiplierText.text.Split(' ')[1];
        LeanTween.move(streakMultiplierText.gameObject, baseScoreTextAnimationEnd, addScoreAnimationLength).setEase(LeanTweenType.easeOutQuart).setOnComplete(AddFinalScoreAnimation);
       // LeanTween.alpha(streakMultiplierText.gameObject, 1f, textFadeTime);
       // LeanTween.alpha(baseScoreText.gameObject, 0f, textFadeTime);


    }

   private void AddFinalScoreAnimation()
   {
        finalScoreText.gameObject.SetActive(true);
        finalScoreText.text = finalScore.ToString();
        ResetText();
        LeanTween.move(finalScoreText.gameObject, finalScoreTextAnimationEnd.position, addFinalScoreAnimationLength).setEase(LeanTweenType.easeInOutQuart).setOnComplete(ScoreScript.AddScore);
        LeanTween.scale(finalScoreText.gameObject, new Vector3(0.5f, 0.5f, 0.5f), addFinalScoreAnimationLength);

        LeanTween.delayedCall(addFinalScoreAnimationLength, ResetFinalScoreText);
   }

    private void ResetText()
    {
        ResetTimerMultiplierText();
        ResetBaseScoreText();
        ResetstreakMultiplierText();
    }

    private void ResetTimerMultiplierText()
    {
        timerMultiplierText.transform.position = timerMultiplierTextAnimationStart.position;
        timerMultiplierText.transform.localScale = Vector3.one;
        timerMultiplierText.gameObject.SetActive(false);
    }

    private void ResetBaseScoreText()
    {
        baseScoreText.transform.position = baseScoreTextAnimationStart.position;
        baseScoreText.transform.localScale = Vector3.one;
        baseScoreText.gameObject.SetActive(false);
    }

    private void ResetstreakMultiplierText()
    {
        streakMultiplierText.transform.position = streakMultiplierTextAnimationStart.position;
        streakMultiplierText.transform.localScale = Vector3.one;
        streakMultiplierText.gameObject.SetActive(false);
    }

    private void ResetFinalScoreText()
    {
        finalScoreText.transform.position = finalScoreTextAnimationStart.position;
        finalScoreText.transform.localScale = Vector3.one;
        finalScoreText.gameObject.SetActive(false);
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
