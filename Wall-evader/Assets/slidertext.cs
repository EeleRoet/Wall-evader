﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slidertext : MonoBehaviour
{
    Text sliderText;
    

    // Start is called before the first frame update
    void Start()
    {
        sliderText = GetComponent<Text>();
    }

    // Update is called once per frame
    public void textUpdate(float value)
    {
        sliderText.text = value.ToString();
    }
}
