using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CountdownTimer : MonoBehaviour
{
   
    [SerializeField] Text CountdownText;
    public pInput pIn;

    //De tijd van de Counter
    public float currentTime = 0f;
    public float startingTime = 9f;
    //De groote ervan
    public float startingSize = 154;
    public float currentSize;
    public float targetSize = 254;
    //De kleur van de Counter
    public Color startingColor = new Color(1,1,1,1);
    public Color currentColor = new Color();
    public Color targetColor = new Color(1,0,0,1);




    

    // Start is called before the first frame update
    void Start()
    {

        currentTime = startingTime;
        currentSize = startingSize;
        currentColor = startingColor;

    }

    // Update is called once per frame
    void Update()
    {

        timeUpdate();
        sizeUpdate();
        colorUpdate();



        if(pIn.resetTimer == true)
        {

            
            countdownReset();

        }


    }

    void sizeUpdate()
    {

        currentSize += (targetSize - startingSize) / 9 * Time.deltaTime;
        CountdownText.fontSize = (int)currentSize;



        if (currentSize >= targetSize && pIn.resetTimer == false)
        {

            currentSize = targetSize;

        }





    }

    void timeUpdate()
    {

        currentTime = pIn.timer;
        CountdownText.text = currentTime.ToString("0");



        if (currentTime <= 0 && pIn.resetTimer == false)
        {

            currentTime = 0;

        }




    }

    void colorUpdate()
    {

        currentColor.g += (targetColor.g - startingColor.g) / 9 * Time.deltaTime;
        currentColor.b += (targetColor.b - startingColor.b) / 9 * Time.deltaTime;
        CountdownText.color = (Color)currentColor;

        if(currentColor.Equals(targetColor) && pIn.resetTimer == false)
        {

            currentColor.Equals(targetColor);

        }





    }
    void countdownReset()
    {

        currentColor.Equals(startingColor);
        currentSize = startingSize;
        currentTime = startingTime;

    }

    

}
