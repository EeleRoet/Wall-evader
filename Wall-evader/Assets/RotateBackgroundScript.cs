using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBackgroundScript : MonoBehaviour
{
    private Vector3 angleTotilt = new Vector3(0, 0, -10f);
    private float tiltduration = 2f;
    private void Start()
    {
        LeanTween.rotate(gameObject, angleTotilt, tiltduration / 2).setOnComplete(TiltRight).setEase(LeanTweenType.easeInOutSine);
    }

    private void TiltLeft()
    {
        LeanTween.rotate(gameObject, angleTotilt, tiltduration).setOnComplete(TiltRight).setEase(LeanTweenType.easeInOutSine);
    }

    private void TiltRight()
    {
        LeanTween.rotate(gameObject, -angleTotilt, tiltduration).setOnComplete(TiltLeft).setEase(LeanTweenType.easeInOutSine);
    }
}
