using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceMember1Script : MonoBehaviour
{
    [SerializeField] private TutorialSequenceScript parentScript;
   
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        parentScript.ToggleLockKnop();
        parentScript.TogglePauseButton();
        parentScript.ToggleScore();
        parentScript.ToggleSliders();
        parentScript.ToggleTabel();
        parentScript.ToggleTimer();
        parentScript.ToggleWall();
        parentScript.ToggleFormule();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
