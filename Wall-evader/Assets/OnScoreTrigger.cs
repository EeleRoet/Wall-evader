using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OnScoreTrigger : MonoBehaviour
{
   [SerializeField] private GenerateData dataScript;
    [SerializeField] private Slider inclineSlider;

   private void OnTriggerEnter(Collider other)
   {
        ScoreScript.AddMarginScore(dataScript.hellingsGetal, inclineSlider.value);
        Debug.Log("jeff");

   }
}
