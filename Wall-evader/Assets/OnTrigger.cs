using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OnTrigger : MonoBehaviour
{
    [SerializeField] private SpawnWalls spawnWallScript;
    [SerializeField] private GameObject wallPrefab;
    [SerializeField] private GenerateData dataScript;
   private void OnTriggerEnter(Collider other)
    {
        
        Destroy(other.gameObject);
        dataScript.GenerateNewData();
        spawnWallScript.SpawnWall(wallPrefab, dataScript.hellingsGetal, dataScript.startgetal);//new generated numbers are used as parameters in SpawnWall()
    }
}
