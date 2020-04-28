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
    public bool working = true;
    public bool resetTimer = false;
    public Button button;
    public Text CountdownText;




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

        rotate = Vector3.forward * (Mathf.Atan(slide.value / 10) * Mathf.Rad2Deg + 90);
        verhoging = slide_verhoging.value * 0.8f;

        target.position = new Vector3(0f, 0.5f + verhoging, -4.25f);

        currentRotation = rotate;


        if (rotate.z >= target.rotation.z || rotate.z <= target.rotation.z)
        {

            Reset();

        }







        timer -= Time.deltaTime;

        if (timer <= 0)
        {

            lockSlider();

        }


        if (resetTimer == true)
        {

            timerReset();

        }



        button.onClick.AddListener(lockSlider);








    }


    public void lockSlider()
    {
        if (working == true)
        {
            slide.interactable = false;
            slide_verhoging.interactable = false;

            viewScript.deactivateObstruction();
            ScoreScript.AddTimerScore((int)timer);
            moveWallScript.SetSpeed();
            scoreAnimationScript.TimerTriggerAnimations((int)timer);

            cTimer.enabled = false;
            CountdownText.enabled = false;

            button.interactable = false;
            Debug.Log(working);


        }

        working = false;
    }



    public void timerReset()
    {
        cTimer.enabled = true;
        timer = 9f;
        slide.interactable = true;
        slide_verhoging.interactable = true;
        resetTimer = false;
        cTimer.countdownReset();
        viewScript.activateObstruction();
        button.interactable = true;
        CountdownText.enabled = true;

        working = true;


    }



    public void Reset()
    {

        this.target.eulerAngles = currentRotation;


    }
}

