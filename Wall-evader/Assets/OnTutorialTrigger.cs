using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTutorialTrigger : MonoBehaviour
{
    [SerializeField] private SequenceMember5Script sequenceScript5;
    [SerializeField] private SequenceMember7Script sequenceScript7;
    private void OnTriggerEnter(Collider other)
    {
        if (sequenceScript5.gameObject.activeSelf)
        {
            sequenceScript5.StartSequence5();
        }
        else if(sequenceScript7.gameObject.activeSelf)
        {
            sequenceScript7.StartSequence7();
        }
    }
}
