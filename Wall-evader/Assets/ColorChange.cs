using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ColorChange : MonoBehaviour
{
    public MeshRenderer meshr;
    public bool defaultColor = false;
    public bool greenColor = false;
    public bool blueColor = false;
    public bool orangeColor = false;
    public bool pinkColor = false;
    public bool greenSColor = false;
    public bool blueSColor = false;
    public bool orangeSColor = false;
    public bool pinkSColor = false;
    public bool goldColor = false;
    // Start is called before the first frame update
    void Start()
    {
        meshr = GetComponent<MeshRenderer>();

        if(defaultColor == true)
        {

            meshr.material.color = new Color(1, 1, 1, 1);

        }
        if (greenColor == true)
        {

            meshr.material.color = new Color(0.08205444F, 0.990566F, 0F,1F);

        }
        if(blueColor == true)
        {

            meshr.material.color = new Color(0f, 0.1000774f,1,1);

        }
        if(orangeColor == true)
        {

            meshr.material.color = new Color(1f, 0.4119051f,0,1);

        }
        if(pinkColor == true)
        {

            meshr.material.color = new Color(1, 0.03529412f, 0.5994968f,1);

        }
        if(greenSColor == true)
        {

            meshr.material.color = new Color(0.08205444F, 0.990566F, 0F, 1F);
            meshr.material.SetFloat("_Metallic", 0.5f);

        }
        if(blueSColor == true)
        {

            meshr.material.color = new Color(0f, 0.1000774f, 1, 1);
            meshr.material.SetFloat("_Metallic", 0.5f);

        }
        if(orangeSColor == true)
        {

            meshr.material.color = new Color(1f, 0.4119051f, 0, 1);
            meshr.material.SetFloat("_Metallic", 0.5f);

        }
        if(pinkSColor == true)
        {

            meshr.material.color = new Color(1, 0.03529412f, 0.5994968f, 1);
            meshr.material.SetFloat("_Metallic", 0.5f);
                
        }
        if(goldColor == true)
        {

            meshr.material.color = new Color(1, 0.8431373f,0,1);
            meshr.material.SetFloat("_Metallic", 0.399f);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
