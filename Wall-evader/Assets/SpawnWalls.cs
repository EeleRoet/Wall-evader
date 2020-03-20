﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWalls : MonoBehaviour
{
    [SerializeField] private GameObject wallPrefab;
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private float unitToForm = 10.0f; //converts in-script units to formula integers.
   //[SerializeField] private Formulescript formulescript;

    // Start is called before the first frame update
    void Start()
    { 
        GameObject newWall = Instantiate(wallPrefab, spawnPosition.position, Quaternion.identity);
        GetFirstChildren(newWall.transform)[0].Rotate(Vector3.forward * (Mathf.Atan(0f) * Mathf.Rad2Deg + 90));
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(wallPrefab, spawnPosition.position, Quaternion.identity);
        }
    }

    public void SpawnWall(float helling, float start)
    {
        GameObject newWall = Instantiate(wallPrefab, spawnPosition.position + (Vector3.up * (start * unitToForm)), Quaternion.identity);
        GetFirstChildren(newWall.transform)[0].Rotate(Vector3.forward * (Mathf.Atan(helling) * Mathf.Rad2Deg + 90));
    }


    //method from stackoverflow answer at: 
    //https://answers.unity.com/questions/496958/how-can-i-get-only-the-childrens-of-a-gameonbject.html
    private Transform[] GetFirstChildren(Transform parent)
    {
        Transform[] children = parent.GetComponentsInChildren<Transform>();
        Transform[] firstChildren = new Transform[parent.childCount];
        int index = 0;
        foreach (Transform child in children)
        {
            if (child.parent == parent)
            {
                firstChildren[index] = child;
                index++;
            }
        }
        return firstChildren;
    }
}