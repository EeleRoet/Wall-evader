using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StreakAnimation : MonoBehaviour
{
    private static Text streakText;
    private static GameObject thisObject;
   

    // Start is called before the first frame update
    void Start()
    {
       
        thisObject = gameObject;
        streakText = GetComponent<Text>();
       
    }

    public static void StartAnimation()
    {
       

    }

    public static void FlipAlpha()
    {
        Color tempColor = new Color();
        tempColor = streakText.color;
        if (tempColor.a == 0)
        {
            tempColor.a = 1;
        }
        else
        {
            tempColor.a = 0;
        }
        streakText.color = tempColor;
    }
}
