using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CountdownTimer : MonoBehaviour
{
   
    [SerializeField] Text CountdownText;
    float currentTime = 0f;
    float startingTime = 9f;


    

    // Start is called before the first frame update
    void Start()
    {

        currentTime = startingTime;
        
    }

    // Update is called once per frame
    void Update()
    {

        currentTime -= 1 * Time.deltaTime;
        CountdownText.text = currentTime.ToString("0");


        if(currentTime <= 0)
        {

            currentTime = 0;

        }
    }
}
