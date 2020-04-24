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
    [SerializeField] private GameObject inclineSlider;
    [SerializeField] private GameObject startSlider;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject formule;





    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("runTutorial", 1) == 1)
        {
            foreach(Transform transform in GetComponentInChildren<Transform>(true))
            {
                sequenceMembers.Add(transform);
                Debug.Log("jeff");
            }
            currentMember = 0;
            BumpCurrentMember();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
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



    public void ToggleTimer()
    {
        timer.SetActive(timer.active ? false : true);
    }

    public void ToggleTabel()
    {
        tabel.SetActive(tabel.active ? false : true);
    }

    public void ToggleLockKnop()
    {
        lockKnop.SetActive(lockKnop.active ? false : true);
    }

    public void ToggleScore()
    {
        score.SetActive(score.active ? false : true);
    }

    public void ToggleWall()
    {
        wall.SetActive(wall.active ? false : true);
    }

    public void ToggleSliders()
    {
        inclineSlider.SetActive(inclineSlider.active ? false : true);
        startSlider.SetActive(startSlider.active ? false : true);
    }

    public void TogglePauseButton()
    {
        pauseButton.SetActive(pauseButton.active ? false : true);
       
    }

    public void ToggleFormule()
    {
        formule.SetActive(formule.active ? false : true);

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
