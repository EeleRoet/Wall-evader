using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SequenceMember1Script : MonoBehaviour
{
    [SerializeField] private TutorialSequenceScript parentScript;
    private ArrayList memberElementsBeingFaded = new ArrayList();
    private Color newColor;
    private float memberElementFadeRate;
    private ArrayList memberElements = new ArrayList();
    private int memberElementsTexts;
    private int currentMemberElement;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        currentMemberElement = 0;
        memberElementFadeRate = 0.025f;
        parentScript.SetLockKnop(false);
        parentScript.SetPauseButton(false);
        parentScript.SetScore(false);
        parentScript.SetSliders(false);
        parentScript.SetTabel(false);
        parentScript.SetTimer(false);
        parentScript.SetWall(false);
        parentScript.SetFormule(false);

        memberElements = parentScript.FillMemberElements(gameObject);
        memberElementsTexts = 0;
        foreach(Transform transform in memberElements)
        {
            if(transform.gameObject.GetComponent<Text>())
            {
                memberElementsTexts++;
            }
        }
        
        SetMemberElementsActive(currentMemberElement);
    }

    void Update()
    {
        
        if (memberElementsBeingFaded.Count != 0)
        {
            
            foreach(RectTransform transform in memberElementsBeingFaded)
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
                else if(transform.gameObject.GetComponent<RawImage>())
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


    public void HandleButtonPress()
    {
        if (memberElements != null)
        {
            if (++currentMemberElement < memberElementsTexts)
            {
                //activate the gameobjects where the tag matches the currentmemberelement
                SetMemberElementsActive(currentMemberElement);
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

    private void FadeMemberElement(RectTransform transform)
    {
        memberElementsBeingFaded.Add(transform);
    }
}
