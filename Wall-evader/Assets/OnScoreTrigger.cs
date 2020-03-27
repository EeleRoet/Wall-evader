using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OnScoreTrigger : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
   {
        ScoreScript.AddScore();

   }
}
