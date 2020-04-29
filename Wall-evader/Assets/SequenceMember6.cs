using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SequenceMember6 : MonoBehaviour
{
    [SerializeField] private TutorialSequenceScript parentScript;
    [SerializeField] private Button nextButton;
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
        parentScript.SetScoreAnimation(false);
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
    }

    public void StartSequence6()
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
                if (currentMemberElement == 1)
                {
                    parentScript.SetScore(true);
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
