using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarginAnimation : MonoBehaviour
{
    private static Text marginText;
    private static GameObject thisObject;
    private static int colorSegment;

    public void Start()
    {
        colorSegment = 85;
        thisObject = gameObject;
        marginText = GetComponent<Text>();
        Color tempColor = new Color();
        tempColor = marginText.color;
        tempColor.a = 0;
        marginText.color = tempColor;
    }

    public static void StartAnimation(float margin)
    {
        string tempText = "";
        if(margin >= 0)
        {
            tempText += "+";
        }
        tempText += System.Math.Round(margin,1).ToString();
        marginText.text = tempText;

        SetTextColor(margin);

        LeanTween.scale(thisObject, Vector3.zero, 0);
        LeanTween.scale(thisObject, new Vector3(1, 1, 1), 1).setOnComplete(FlipAlpha);
        
    }

    private static void SetTextColor(float margin)
    {
        margin *= 10;
        FlipAlpha();
        Color tempColor = new Color();
        tempColor = marginText.color;
        if( Mathf.Abs(margin) <= 3)
        {
            tempColor.g = 255 - colorSegment * margin;
            tempColor.r = colorSegment * margin;
            
        }
        else if (Mathf.Abs(margin) <= 6)
        {
            tempColor.r = 255 - colorSegment * margin % 3;
            tempColor.g = colorSegment * margin % 3;
        }
        else
        {
            tempColor.r = 255;
            tempColor.g = 0;
        }
        tempColor.b = 0;
        marginText.color = tempColor;
    }

    private static void FlipAlpha()
    {
        Color tempColor = new Color();
        tempColor = marginText.color;
        if (tempColor.a == 0)
        {
            tempColor.a = 1;
        }
        else
        {
            tempColor.a = 0;
        }
        marginText.color = tempColor;
    }
}
