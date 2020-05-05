using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class HandleParticlesScript : MonoBehaviour
{
    private static ArrayList particleSystems;
    private static bool runSystems;
    private static float counter;
    [SerializeField] int effectRunTime;

    private void Start()
    {

        particleSystems = new ArrayList();
        runSystems = false;
        counter = 0;
        

        foreach(Transform transform in GetComponentInChildren<Transform>(true))
        {
            particleSystems.Add(transform);
        }
        StopParticleSystems();
    }

    private void Update()
    {
        if (runSystems)
        {
            if(counter > effectRunTime)
            {
                runSystems = false;
                counter = 0;
                StopParticleSystems();
            }
            counter += Time.deltaTime;
        }
    }

    private static void StopParticleSystems()
    {
        foreach(Transform transform in particleSystems)
        {
            transform.gameObject.GetComponent<VisualEffect>().Stop();
        }
    }

    public static void RunParticleSystems()
    {
        runSystems = true;
        foreach (Transform transform in particleSystems)
        {
            transform.gameObject.GetComponent<VisualEffect>().Play();
        }
    }
}
