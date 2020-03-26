using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigger : MonoBehaviour
{
     public SpawnWalls spawnWallScript;
    public GameObject wallPrefab;
    //[SerializeField] private NumberGeneratorScipt numberGeneratorScript;
   private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        //numberGereratorScript.generateNew();
        spawnWallScript.SpawnWall(wallPrefab, 0, 0);//new generated numbers are used as parameters in SpawnWall()
    }
}
