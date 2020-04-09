using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomInTrigger : MonoBehaviour
{
    [SerializeField] private DynamicCamera dynamicCamera;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        dynamicCamera.zoomIn = true;
        Debug.Log(dynamicCamera.zoomIn);
    }
}
