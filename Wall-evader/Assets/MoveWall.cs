using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{
    private Rigidbody wallBody;
    private float timeToScoreTrigger;
    private float distanceToScoreTrigger;
    private float speed;
    [SerializeField] private float SerializeSpeed;
    [SerializeField] private Transform scoreTriggerTransform;

    // Start is called before the first frame update
    void Start()
    {
        ResetSpeed();
        timeToScoreTrigger = 2.7f;
        wallBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        wallBody.velocity = Vector3.back * speed;
    }

    public void SetSpeed()
    {
        distanceToScoreTrigger = gameObject.transform.position.z - scoreTriggerTransform.position.z;
        speed = distanceToScoreTrigger / timeToScoreTrigger;
    }

    public void ResetSpeed()
    {
        speed = SerializeSpeed;
    }
}
