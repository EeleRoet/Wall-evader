using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateData : MonoBehaviour
{
    Text text;
    Text[] data;
    // Start is called before the first frame update
    void Start()
    {
        data = GetComponentsInChildren<Text>();

        float randomY = Random.Range(0, 10);
        float hellingsGetal = Mathf.Round(Mathf.Atan(Random.Range(0, 80)*Mathf.Deg2Rad));

        Debug.Log(randomY);
        Debug.Log(hellingsGetal);

        foreach (Text item in data)
        {
            if (item.tag == "Y_waarde")
            {
                item.text = randomY.ToString();
                randomY += hellingsGetal;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
