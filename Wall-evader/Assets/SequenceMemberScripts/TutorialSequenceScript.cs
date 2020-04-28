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
    [SerializeField] private GameObject lockKnop;
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
        currentMember++;
        tempTransform = sequenceMembers[currentMember - 1] as Transform;
        tempTransform.gameObject.SetActive(true);
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
        lockKnop.SetActive(newActive);
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

    public void setScoreAnimation(bool newActive)
    {
        scoreAnimation.SetActive(newActive);
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
