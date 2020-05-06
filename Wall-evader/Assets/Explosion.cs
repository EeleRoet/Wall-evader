﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Explosion : MonoBehaviour
{
    public pInput pIn;
    [SerializeField] private DynamicCamera cameraScript; 
    public Slider slider;
    public MoveWall mWall;
    public Canvas canvas;
    public GameObject scoreAnimation;
    public Text scoreCalc;
    private System.Random r = new System.Random();
    [SerializeField] private GameObject ExplosionBlocks;

    private bool switchedCameraFollow = false;
    public float explosionSize = 0.3f;
    public int explosionRow = 3;
    public bool ExplosionGameover = false;

    public float timer = 1.5f;


  

    public void Explode()
    {


        canvas.enabled = false;

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<MeshCollider>().enabled = false;
        scoreAnimation.SetActive(false);


       
        Time.timeScale = 0.5f;
        mWall.StopWall();
        cameraScript.zoomIn = false;
        createExplosion();
    }

    void createExplosion()
    {
        ExplosionBlocks.SetActive(true);
        ExplosionBlocks.transform.position = this.transform.position;
        ExplosionBlocks.transform.rotation = this.transform.rotation;

        foreach(Transform transform in ExplosionBlocks.GetComponentInChildren<Transform>(true))
        {
            if (transform.gameObject.GetComponent<Rigidbody>())
            {
                if (!switchedCameraFollow)
                {
                    cameraScript.SwitchTargets(transform);
                    switchedCameraFollow = true;
                }


                transform.gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(r.Next(-100, 100), r.Next(-100, 100), r.Next(-100, 100));
                transform.gameObject.GetComponent<Rigidbody>().velocity = mWall.gameObject.GetComponent<Rigidbody>().velocity;
            }
        }
    }

   
    
}