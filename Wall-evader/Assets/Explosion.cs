﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Explosion : MonoBehaviour
{
    public pInput pIn;
    public Slider slider;
    public MoveWall mWall;
    public Canvas canvas;
    public ScoreCalcAnimations SCA;
    public Text scoreCalc;


    public float explosionSize = 0.5f;
    public int explosionRow = 2;
    public bool ExplosionGameover = false;

    public float timer = 3;



    public void Explode()
    {


        canvas.enabled = false;

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<MeshCollider>().enabled = false;



        for (int x = 0; x < explosionRow; x++)
        {
            for (int y = 0; y < explosionRow; y++)
            {
                for (int z = 0; z < explosionRow; z++)
                {

                    createExplosion(x, y, z);
                    


                }
            }
        }

        

    }

    void createExplosion(float x, float y, float z)
    {

        //maakt het object aan
        GameObject explosionCube;
        explosionCube = GameObject.CreatePrimitive(PrimitiveType.Cube);


        //bepaald de positie
        explosionCube.transform.position = gameObject.transform.position + new Vector3((explosionSize * x) - explosionSize, (explosionSize * y) - explosionSize, (explosionSize * z) - explosionSize );
        explosionCube.transform.rotation = gameObject.transform.rotation;
        explosionCube.transform.localScale = new Vector3(explosionSize, explosionSize, explosionSize);

        //maakt een rigidbody aan
        explosionCube.AddComponent<Rigidbody>();
        explosionCube.GetComponent<Rigidbody>().mass = explosionSize;
        explosionCube.GetComponent<Rigidbody>().angularVelocity.z.Equals(Random.Range(-10f,10f));

        explosionCube.AddComponent<BoxCollider>();
        explosionCube.GetComponent<BoxCollider>();


        if(explosionCube.transform.position.y <= 0.5)
        {

            explosionCube.transform.position.y.Equals(0.5);

        }



    }

   
    
}