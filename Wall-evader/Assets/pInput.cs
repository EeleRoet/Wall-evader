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
    public float timer = 0.0f;
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



        timer+= Time.deltaTime;

        if(timer >= 9 && active == true)
        {
            slide.interactable = false;
            slide_verhoging.interactable = false;
            active = false;
            viewScript.deactivateObstruction();
            ScoreScript.AddTimerScore((int)timer);
        }

        if(resetTimer == true)
        {
            
            timerReset();
            resetTimer = false;
            active = true;
        }

       // Debug.Log("0"+timer);
}


    public void timerReset()
    {

        timer = 0;
        slide.interactable = true;
        slide_verhoging.interactable = true;
        resetTimer = false;
        viewScript.activateObstruction();

    }

    public void Reset()
    {

        this.target.eulerAngles = currentRotation;

    }
}
