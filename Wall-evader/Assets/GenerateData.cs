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
    List<Text> x_waardes_tabel = new List<Text>();
    List<float> x_waardes = new List<float>(3);

    public float randomY, hellingsGetal, startgetal, y_waarde1, y_waarde2, y_waarde3;

    public float baseValue = 0, newValue;

    public void GenerateNewData()
    {
        for (int i = 0; i < 3; i++)
        {
            newValue = baseValue + UnityEngine.Random.Range(1, 5);
            x_waardes.Add(newValue);
            baseValue = newValue;
        }

        randomY = UnityEngine.Random.Range(0, 5);
        startgetal = randomY;

        if(round <= 5)
        {
            hellingsGetal = (float)Math.Round(Mathf.Tan(UnityEngine.Random.Range(0, 65) / 180f * Mathf.PI) * 2, MidpointRounding.AwayFromZero) / 2f;
        }
        else if (round <= 12)
        {
            hellingsGetal = (float)Math.Round(Mathf.Tan(UnityEngine.Random.Range(0, 46) / 180f * Mathf.PI), 1);
        }
        else
        {
            hellingsGetal = (float)Math.Round(Mathf.Tan(UnityEngine.Random.Range(0, 75) / 180f * Mathf.PI), 1);
        }

        if (UnityEngine.Random.Range(0.0f, 1.0f) > 0.5)
        {
            hellingsGetal *= -1;
        }

        y_waarde1 = (float)System.Math.Round(startgetal + hellingsGetal * x_waardes[0],1);
        y_waarde2 = (float)System.Math.Round(startgetal + hellingsGetal * x_waardes[1], 1);
        y_waarde3 = (float)System.Math.Round(startgetal + hellingsGetal * x_waardes[2], 1);
        
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

        foreach (Text text in GetComponentsInChildren<Text>(true))
        {
            if (text.CompareTag("X_waarde"))
            {
                x_waardes_tabel.Add(text);
            }        
        }

        for (int i = 0; i < 3; i++)
        {
            x_waardes_tabel[i].text = x_waardes[i].ToString();
        }
    }
}
