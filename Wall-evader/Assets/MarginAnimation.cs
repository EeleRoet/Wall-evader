using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarginAnimation : MonoBehaviour
{
    private static Text marginText;
    private static GameObject thisObject;

    public void Start()
    {
        thisObject = gameObject;
        marginText = GetComponent<Text>();
    }

    public static void StartAnimation(float margin)
    {
        string tempText = "";
       
        if(margin >= 0)
        {
            tempText += "+";
            tempText += margin.ToString();
        }
        else
        {
            tempText += margin.ToString();
        }

        marginText.text = tempText;

        Color tempColor = new Color();
       // tempColor
        marginText.color = new Color();

        LeanTween.scale(thisObject, Vector3.zero, 0);
        LeanTween.scale(thisObject, new Vector3(1, 1, 1), 1);
    }
}
