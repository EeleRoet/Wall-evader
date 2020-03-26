using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateData : MonoBehaviour
{
    Text text;
    Text[] data;

    public float randomY, xWaarde, hellingsGetal;
    
    // Start is called before the first frame update
    void Start()
    {
        data = GetComponentsInChildren<Text>();

        randomY = Random.Range(0, 5);
        xWaarde = 0;
        hellingsGetal = (float)System.Math.Round(Mathf.Tan(Random.RandomRange(0, 80) / 180f * Mathf.PI), 1);

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
        GenerateNewData();
        Debug.Log(randomY);
        Debug.Log(hellingsGetal);
    }

    public void GenerateNewData()
    {
        randomY = Random.Range(0, 5);
        hellingsGetal = (float)System.Math.Round(Mathf.Tan(Random.RandomRange(0, 80) / 180f * Mathf.PI), 1);

        if (Random.Range(0, 1) == 0)
        {
            hellingsGetal *= -1;
        }
    }
}
