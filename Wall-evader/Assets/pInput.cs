using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pInput : MonoBehaviour
{

    public Rigidbody rbody;
    public Transform target;
    public Slider slide;
    Vector3 position;

    int verhoging = 0;
    int rotate;


    // Start is called before the first frame update
    void Start()
    {

        target = GetComponent<Transform>();
        rbody = GetComponent<Rigidbody>();
        



        target.position = new Vector3(-0.6f, 0.5f, 2f);

    }

    // Update is called once per frame
    void Update()
    {

        
            transform.Rotate((new Vector3(0, 0, rotate)), Space.Self);
            target.position = new Vector3(-0.6f, 0.5f + verhoging, 2f);
        


        rotate = (int)Mathf.Cos(slide.value);
    }

    private void Reset()
    {

    }
}
