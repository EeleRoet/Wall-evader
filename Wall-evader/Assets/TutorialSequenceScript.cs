using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSequenceScript : MonoBehaviour
{
    private ArrayList sequenceMembers = new ArrayList();
    private int currentMember;

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
