using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pInput : MonoBehaviour
{

    public Rigidbody rbody;
    public Transform target;
    public Slider slide;
    public Slider slide_verhoging;
    public float timer;
    public bool active = true;
    public bool resetTimer = false;

    OnSpawnTrigger onST;

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



        timer += 1 / 60;

        if(timer >= 2)
        {
            active = false;
        }

        if(resetTimer == true)
        {
            timerReset();
        }

        
}


    public void timerReset()
    {

        timer = 0;
        active = true;
        resetTimer = false;

    }

    public void Reset()
    {

        this.target.eulerAngles = currentRotation;

    }
}
