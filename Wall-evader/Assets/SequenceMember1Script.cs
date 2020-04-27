using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SequenceMember1Script : MonoBehaviour
{
    [SerializeField] private TutorialSequenceScript parentScript;
    private ArrayList memberElements = new ArrayList();
    private int memberElementsTexts;
    private int currentMemberElement;

    // Start is called before the first frame update
    void Start()
    {
        currentMemberElement = 0;
        Time.timeScale = 0;
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

   

    public void HandleButtonPress()
    {
        if (memberElements != null)
        {
            if (++currentMemberElement <= memberElementsTexts - 1)
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
        foreach (Transform transform in memberElements)
        {
            if (transform.CompareTag(memberElement.ToString()))
            {
                transform.gameObject.SetActive(true);
            }
        }
    }
}
