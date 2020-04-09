using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pInput : MonoBehaviour
{
    public viewObstructionScript viewScript;
    public Rigidbody rbody;
    public Transform target;
    public Slider slide;
    public Slider slide_verhoging;
    public int timer = 0;
    public bool active = true;
    public bool resetTimer = false;

   

    public float verhoging = 0;
    public Vector3 rotate;
    public Vector3 currentRotation;

    // Start is called before the first frame update
    void Start()
    {

        target = GetComponent<Transform>();
        rbody = GetComponent<Rigidbody>();

        this.target.eulerAngles = currentRotation;


        target.position = new Vector3(0f, 0.5f, -4.25f);

    }



    // Update is called once per frame
    void Update()
    {

        rotate = Vector3.forward * (Mathf.Atan(slide.value/10) * Mathf.Rad2Deg + 90);
        verhoging = slide_verhoging.value*0.8f;

        target.position = new Vector3(0f, 0.5f + verhoging, -4.25f);

        currentRotation = rotate;

        if(rotate.z >= target.rotation.z || rotate.z <= target.rotation.z )
        {

                Reset();

        }



        timer++;

        if(timer >= 300 && active == true)
        {
            slide.interactable = false;
            slide_verhoging.interactable = false;
            active = false;
            viewScript.destroyObstruction();
        }

        if(resetTimer == true)
        {
            timerReset();
        }

 
}


    public void timerReset()
    {

        timer = 0;
        slide.interactable = true;
        resetTimer = false;

    }

    public void Reset()
    {

        this.target.eulerAngles = currentRotation;

    }
}
