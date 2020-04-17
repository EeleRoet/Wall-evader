using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class createHighscoretable : MonoBehaviour
{
    public Text distanceText;

    public Canvas canvas;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Text tempTextBox = Instantiate(distanceText, pos, rot) as Text;
            //tempTextBox.transform.SetParent(Canvas.transform, false);
        }
    }
}