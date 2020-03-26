using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInput : MonoBehaviour
{

    Rigidbody rigidbody;
    Transform transform;
    
    int verhoging = 0;
    int x_change = 1;


    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = new Quaternion(0,0,-90,0);
        transform.position = new Vector3(-0.6f, 0.5f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = new Quaternion(x_change,0,-90,0);
        transform.position = new Vector3(-0.6f, 0.5f+verhoging, 2f);
    }

    private void Reset()
    {
       
    }
}
