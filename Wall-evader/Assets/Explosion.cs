using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    pInput pIn;

    public float explosionSize = 0.5f;
    public int explosionRow = 2;
    
    float timer= 0;

    public void Update()
    {
        timer += Time.deltaTime;


    }

    public void Explode()
    {

        gameObject.SetActive(false);

        for(int x = 0; x < explosionRow; x++) {
            for (int y = 0; y < explosionRow; y++) {
                for (int z = 0; z < explosionRow; z++)
                {

                    createExplosion(x,y,z);

                }
            }
        }

    }

    void createExplosion(int x, int y, int z)
    {
        //maakt het object aan
        GameObject explosionCube;
        explosionCube = GameObject.CreatePrimitive(PrimitiveType.Cube);


        //bepaald de positie
        explosionCube.transform.position = pIn.target.position + new Vector3(explosionSize * x, explosionSize * y, explosionSize * z);
        explosionCube.transform.localScale = new Vector3(explosionSize, explosionSize, explosionSize);

        //maakt een rigidbody aan
        explosionCube.AddComponent<Rigidbody>();
        explosionCube.GetComponent<Rigidbody>().mass = explosionSize;

    }
}
