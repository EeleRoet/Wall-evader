﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Explosion : MonoBehaviour
{
    public pInput pIn;
    public Slider slider;
    public MoveWall mWall;

    public float explosionSize = 0.5f;
    public int explosionRow = 2;
    public bool ExplosionGameover = false;

    public float timer = 3;



    public void Explode()
    {



        gameObject.SetActive(false);



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
        

        ExplosionGameover = true;

        if(explosionCube.transform.position.y <= 0.5)
        {

            explosionCube.transform.position.y.Equals(0.5);

        }


             void Update()
         {


             timer -= Time.deltaTime;
             explosionCube.GetComponent<Rigidbody>().velocity = Vector3.back * mWall.speed;

            if(timer <= 0)
            {

                FindObjectOfType<PauseMenu>().GameOver();

            }

         }

    }

   
    
}