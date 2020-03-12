using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWalls : MonoBehaviour
{
    [SerializeField] private GameObject wallPrefab;
    [SerializeField] private Transform spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(wallPrefab, spawnPosition.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(wallPrefab, spawnPosition.position, Quaternion.identity);
        }
    }
}
