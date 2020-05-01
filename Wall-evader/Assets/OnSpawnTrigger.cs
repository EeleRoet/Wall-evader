using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OnSpawnTrigger : MonoBehaviour
{
    [SerializeField] private SpawnWalls spawnWallScript;
    [SerializeField] private GenerateData dataScript;
    [SerializeField] private DynamicCamera dynamicCamera;
    public pInput pIn;

    

    private void OnTriggerEnter(Collider other)
    {
        spawnWallScript.SpawnWall();
        
        pIn.resetTimer = true;
        dynamicCamera.zoomIn = false;
    }
}
