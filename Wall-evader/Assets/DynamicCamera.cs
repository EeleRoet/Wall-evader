using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicCamera : MonoBehaviour
{
    private Transform target;
    [SerializeField] private Transform fullPlayerTarget;
    private Transform explodedPlayerTarget;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public Vector3 zoomOffset;

    public bool zoomIn;

    void Start()
    {
        zoomIn = false;
        target = fullPlayerTarget;
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothSpeed);
        transform.position = smoothedPosition;

        if (zoomIn)
        {
            cameraZoom();
        }

    }

    public void SwitchTargets(Transform explodedTransform)
    {
        explodedPlayerTarget = explodedTransform;
        target = explodedPlayerTarget;
    }

    void cameraZoom()
    {
        Vector3 desiredPosition = target.position + zoomOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothSpeed);
        transform.position = smoothedPosition;
    }
}
