using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slidertext : MonoBehaviour
{
    Text sliderText;
    [SerializeField] private Text hellingsgetal;
    

    // Start is called before the first frame update
    void Start()
    {
        sliderText = GetComponent<Text>();
        
    }

    // Update is called once per frame
    public void textUpdate(float value)
    {
        sliderText.text = (value/10).ToString();
        hellingsgetal.text = (value/10).ToString();

    }
}
