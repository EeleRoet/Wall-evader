using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBeltPart : MonoBehaviour
{
    private Rigidbody beltBody;
    [SerializeField] private float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        beltBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        beltBody.velocity = Vector3.back * speed;
    }
}
