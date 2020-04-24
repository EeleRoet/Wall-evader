using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pInput : MonoBehaviour
{
    [SerializeField] private MoveWall moveWallScript;
    [SerializeField] private ScoreCalcAnimations scoreAnimationScript;
    public CountdownTimer cTimer;
    public viewObstructionScript viewScript;
    public Rigidbody rbody;
    public Transform target;
    public Slider slide;
    public Slider slide_verhoging;
    public float timer;
    public bool active = true;
    public bool resetTimer = false;
    public Button button;
    

   

    public float verhoging = 0;
    public Vector3 rotate;
    public Vector3 currentRotation;

    // Start is called before the first frame update
    void Start()
    {
        timer = 9;
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



        timer -= Time.deltaTime;
        

        if(timer <= 0 && active == true)
        {

            active = false;
            lockSlider();
           

        }
        else
        {

            active = true;

        }

        if(resetTimer == true)
        {
            
            timerReset();
            
        }

        if(active == true)
        {

            active = false;
            button.onClick.AddListener(lockSlider);

        }

        else
        {

            active = true;

        }

        if(timer <= 0)
        {

            timer = 0;

        }

 
    }


    public void lockSlider()
    {

        slide.interactable = false;
        slide_verhoging.interactable = false;
        
        viewScript.deactivateObstruction();
        ScoreScript.AddTimerScore((int)timer);
        moveWallScript.SetSpeed();
        scoreAnimationScript.TimerTriggerAnimations((int)timer);

        cTimer.enabled = false;
        cTimer.currentSize = 0;

        button.interactable = false;
        Debug.Log("werkaub");

        timer = cTimer.currentTime;

    }



    public void timerReset()
    {

        timer = 9f;
        slide.interactable = true;
        slide_verhoging.interactable = true;
        resetTimer = false;

        viewScript.activateObstruction();

        active = true;
       

    }



    public void Reset()
    {

        this.target.eulerAngles = currentRotation;
        

    }
}
