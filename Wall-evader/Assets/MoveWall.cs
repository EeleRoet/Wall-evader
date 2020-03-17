using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{
    private Rigidbody wallBody;
    [SerializeField] private float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        wallBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        wallBody.velocity = Vector3.back * speed;
    }
}
