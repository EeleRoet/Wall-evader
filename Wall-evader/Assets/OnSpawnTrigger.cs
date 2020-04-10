﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OnSpawnTrigger : MonoBehaviour
{
    [SerializeField] private SpawnWalls spawnWallScript;
    [SerializeField] private GameObject wallPrefab;
    [SerializeField] private GenerateData dataScript;
    public pInput pIn;
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        dataScript.GenerateNewData();
        spawnWallScript.SpawnWall(dataScript.hellingsGetal, dataScript.startgetal);
        pIn.resetTimer = true;
    }
}
