using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateData : MonoBehaviour
{
    private int round = 1;
    Text text;
    Text[] data;

    public float randomY, hellingsGetal, startgetal, y_waarde1, y_waarde2, y_waarde3;


    public void GenerateNewData()
    {
       
        randomY = UnityEngine.Random.Range(0, 5);
        startgetal = randomY;

        if(round <= 5)
        {
            hellingsGetal = (float)System.Math.Round(Mathf.Tan(UnityEngine.Random.RandomRange(0, 75) / 180f * Mathf.PI) * 2, MidpointRounding.AwayFromZero) / 2f;
        }
        else if (round <= 12)
        {
            hellingsGetal = (float)System.Math.Round(Mathf.Tan(UnityEngine.Random.RandomRange(0, 46) / 180f * Mathf.PI), 1);
        }
        else
        {
            hellingsGetal = (float)System.Math.Round(Mathf.Tan(UnityEngine.Random.RandomRange(0, 75) / 180f * Mathf.PI), 1);
        }

        if (UnityEngine.Random.Range(0.0f, 1.0f) > 0.5)
        {
            hellingsGetal *= -1;
        }

        y_waarde1 = (float)System.Math.Round(startgetal + hellingsGetal,1);
        y_waarde2 = (float)System.Math.Round(startgetal + hellingsGetal * 3, 1);
        y_waarde3 = (float)System.Math.Round(startgetal + hellingsGetal * 4, 1);
        
        FillTabel();
        round++;
    }

    private void FillTabel()
    {
        data = GetComponentsInChildren<Text>();

        for (int i = 0; i < data.Length; i++)
        {
            if (data[i].tag == "Y_waarde")
            {
                data[i].text = y_waarde1.ToString();
            }
            if (data[i].tag == "Y_waarde2")
            {
                data[i].text = y_waarde2.ToString();
            }
            if (data[i].tag == "Y_waarde3")
            {
                data[i].text = y_waarde3.ToString();
            }
        }
    }
}
