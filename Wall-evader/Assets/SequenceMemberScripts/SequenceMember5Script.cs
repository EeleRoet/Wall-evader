using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SequenceMember5Script : MonoBehaviour
{
    [SerializeField] private TutorialSequenceScript parentScript;
    [SerializeField] private GenerateData dataScript;
    [SerializeField] private Button nextButton;
    [SerializeField] private pInput playerInputScript;
    private ArrayList memberElementsBeingFaded = new ArrayList();
    private Color newColor;
    private float memberElementFadeRate;
    private ArrayList memberElements = new ArrayList();
    private int memberElementsTexts;
    private int currentMemberElement;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        currentMemberElement = 0;
        memberElementFadeRate = 0.025f;
        parentScript.SetLockKnop(false);
        parentScript.SetPauseButton(false);
        parentScript.SetScore(false);
        parentScript.SetSliders(true);
        parentScript.SetTabel(true);
        parentScript.SetTimer(false);
        parentScript.SetWall(true);
        parentScript.SetFormule(true);
        parentScript.setScoreAnimation(false);
        nextButton.gameObject.SetActive(false);

        memberElements = parentScript.FillMemberElements(gameObject);
        memberElementsTexts = 0;
        foreach (Transform transform in memberElements)
        {
            if (transform.gameObject.GetComponent<Text>())
            {
                memberElementsTexts++;
            }
        }

       
    }

    void Update()
    {
        if (memberElementsBeingFaded.Count != 0)
        {

            foreach (RectTransform transform in memberElementsBeingFaded)
            {
                if (transform.gameObject.GetComponent<Text>())
                {
                    if (transform.gameObject.GetComponent<Text>().color.a < 1)
                    {
                        newColor = transform.gameObject.GetComponent<Text>().color;
                        newColor.a += memberElementFadeRate;
                        transform.gameObject.GetComponent<Text>().color = newColor;
                    }
                    else
                    {
                        memberElementsBeingFaded.Remove(transform);
                        return;
                    }
                }
                else if (transform.gameObject.GetComponent<RawImage>())
                {
                    if (transform.gameObject.GetComponent<RawImage>().color.a < 1)
                    {
                        newColor = transform.gameObject.GetComponent<RawImage>().color;
                        newColor.a += memberElementFadeRate;
                        transform.gameObject.GetComponent<RawImage>().color = newColor;
                    }
                    else
                    {
                        memberElementsBeingFaded.Remove(transform);
                        return;
                    }
                }
            }

        }

        if(currentMemberElement == 1)
        {
           if( System.Math.Round( parentScript.inclineSlider.value / 10, 1) == System.Math.Round( dataScript.hellingsGetal, 1) && parentScript.startSlider.value == dataScript.startgetal)
            {

                parentScript.BumpCurrentMember();
                Time.timeScale = 1;
                playerInputScript.lockSlider();
                parentScript.SetLockKnop(true);
                parentScript.SetPauseButton(true);
                parentScript.SetScore(true);
                parentScript.SetSliders(true);
                parentScript.SetTabel(true);
                parentScript.SetTimer(true);
                parentScript.SetWall(true);
                parentScript.SetFormule(true);
                parentScript.setScoreAnimation(true);
            }
        }
    }

    public void StartSequence5()
    {
        Time.timeScale = 0;
        SetMemberElementsActive(currentMemberElement);
        nextButton.gameObject.SetActive(true);
    }


    public void HandleButtonPress()
    {
        if (memberElements != null)
        {
            SetMemberElementsNonActive(currentMemberElement);
            if (++currentMemberElement < memberElementsTexts)
            {
                SetMemberElementsActive(currentMemberElement);
                if(currentMemberElement == 1)
                {
                    nextButton.gameObject.SetActive(false);
                }
            }
            else
            {
                parentScript.BumpCurrentMember();
            }
        }
        else
        {
            parentScript.BumpCurrentMember();
        }
    }

    private void SetMemberElementsActive(int memberElement)
    {
        foreach (RectTransform transform in memberElements)
        {
            if (transform.CompareTag(memberElement.ToString()))
            {

                transform.gameObject.SetActive(true);
                FadeMemberElement(transform);
            }
        }
    }

    private void SetMemberElementsNonActive(int memberElement)
    {
        foreach (RectTransform transform in memberElements)
        {
            if (transform.CompareTag(memberElement.ToString()))
            {
                transform.gameObject.SetActive(false);
            }
        }
    }

    private void FadeMemberElement(RectTransform transform)
    {
        memberElementsBeingFaded.Add(transform);
    }
}
