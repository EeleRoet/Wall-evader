using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timercountdown : MonoBehaviour
{
    Text timerText;
    pInput pIn;
    


    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<Text>();

    }

    // Update is called once per frame
    public void textUpdate(float value)
    {
        timerText.text = (9-pIn.timer).ToString();
        
    }
}
