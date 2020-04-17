using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CountdownTimer : MonoBehaviour
{
    pInput pIn;
    Text Countdown;
    

    // Start is called before the first frame update
    void Start()
    {
        
        Countdown = GetComponent<Text>();
        pIn = GetComponent<pInput>();

    }

    // Update is called once per frame
    public void textUpdate(float value)
    {

        Countdown.text = value.ToString();

    }
}
