using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTutorialTrigger : MonoBehaviour
{
    [SerializeField] private SequenceMember5Script sequenceScript;
    private void OnTriggerEnter(Collider other)
    {
        if (sequenceScript.gameObject.activeSelf)
        {
            sequenceScript.StartSequence5();
        }
    }
}
