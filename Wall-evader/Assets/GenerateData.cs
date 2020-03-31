using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateData : MonoBehaviour
{
    Text text;
    Text[] data;

    public float randomY, xWaarde, hellingsGetal, startgetal;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GenerateNewData()
    {
        randomY = Random.Range(0, 5);
        startgetal = randomY;
        hellingsGetal = (float)System.Math.Round(Mathf.Tan(Random.RandomRange(0, 80) / 180f * Mathf.PI), 1);

        if (Random.Range(0.0f, 1.0f) > 0.5)
        {
            hellingsGetal *= -1;
        }

        FillTabel();
    }

    private void FillTabel()
    {
        data = GetComponentsInChildren<Text>();
        xWaarde = 0;
       

        foreach (Text item in data)
        {
            if (item.tag == "Y_waarde")
            {
                item.text = randomY.ToString();
                randomY += hellingsGetal;
            }
            if (item.tag == "X_waarde")
            {
                item.text = xWaarde.ToString();
                xWaarde += 1;
            }
        }
    }
}
