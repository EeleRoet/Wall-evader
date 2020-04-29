using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialSequenceScript : MonoBehaviour
{
    private ArrayList sequenceMembers = new ArrayList();
    private int currentMember;

    [SerializeField] private GameObject timer;
    [SerializeField] private GameObject tabel;
    [SerializeField] public Button lockKnop;
    [SerializeField] private GameObject score;
    [SerializeField] private GameObject wall;
    [SerializeField] public Slider inclineSlider;
    [SerializeField] public Slider startSlider;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject formule;
    [SerializeField] private GameObject scoreAnimation;
    [SerializeField] private GameObject tutorialTrigger;





    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("runTutorial", 1);
        if(PlayerPrefs.GetInt("runTutorial", 1) == 1)
        {
            foreach(Transform transform in GetComponentInChildren<Transform>(true))
            {
                sequenceMembers.Add(transform);
            }
            currentMember = 0;
            BumpCurrentMember();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void BumpCurrentMember()
    {
        Transform tempTransform;
        if (currentMember != 0)
        {
            tempTransform = sequenceMembers[currentMember - 1] as Transform;
            tempTransform.gameObject.SetActive(false);
        }
        if (++currentMember - 1 < sequenceMembers.Count)
        {
            tempTransform = sequenceMembers[currentMember - 1] as Transform;
            tempTransform.gameObject.SetActive(true);
        }
        else
        {
            tempTransform = sequenceMembers[currentMember - 2] as Transform;
            tempTransform.gameObject.SetActive(false);
            EndTutorial();
        }
    }

    private void EndTutorial()
    {
        Time.timeScale = 1;
        SetAllUI(true);
        lockKnop.interactable = true;
        ChangePlayerPref();
        gameObject.SetActive(false);
    }

    public void SetTimer(bool newActive)
    {
        timer.SetActive(newActive);
    }

    public void SetTabel(bool newActive)
    {
        tabel.SetActive(newActive);
    }

    public void SetLockKnop(bool newActive)
    {
        lockKnop.gameObject.SetActive(newActive);
    }

    public void SetScore(bool newActive)
    {
        score.SetActive(newActive);
    }

    public void SetWall(bool newActive)
    {
        wall.SetActive(newActive);
    }

    public void SetSliders(bool newActive)
    {
        inclineSlider.gameObject.SetActive(newActive);
        startSlider.gameObject.SetActive(newActive);
    }

    public void SetPauseButton(bool newActive)
    {
        pauseButton.SetActive(newActive);
       
    }

    public void SetFormule(bool newActive)
    {
        formule.SetActive(newActive);
    }

    public void SetScoreAnimation(bool newActive)
    {
        scoreAnimation.SetActive(newActive);
    }

    private void SetAllUI(bool newActive)
    {
        SetTimer(newActive);
        SetTabel(newActive);
        SetLockKnop(newActive);
        SetScore(newActive);
        SetWall(newActive);
        SetSliders(newActive);
        SetPauseButton(newActive);
        SetFormule(newActive);
        SetScoreAnimation(newActive);
    }

    private void ChangePlayerPref()
    {
        PlayerPrefs.SetInt("runTutorial", 0);
    }

    public ArrayList FillMemberElements(GameObject gameobjectToCheck)
    {
        ArrayList tempList = new ArrayList();
       
        foreach (RectTransform transform in gameobjectToCheck.GetComponentInChildren<RectTransform>(true))
        {
           tempList.Add(transform);
        }
        return tempList;
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
