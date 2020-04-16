using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWalls : MonoBehaviour
{
    [SerializeField] private GameObject wall;
    [SerializeField] private Transform spawnPosition;
    private float unitToForm = 0.8f; //converts in-script units to formula integers.
    [SerializeField] private GenerateData dataScript;


    // Start is called before the first frame update
    void Start()
    {
        
        SpawnWall();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnWall()
    {
        dataScript.GenerateNewData();


        wall.transform.position = spawnPosition.position + (Vector3.up * (dataScript.startgetal * unitToForm));
        GetFirstChildren(wall.transform)[0].eulerAngles = new Vector3(0, 0, 0);
        GetFirstChildren(wall.transform)[0].Rotate(Vector3.forward * (Mathf.Atan(dataScript.hellingsGetal) * Mathf.Rad2Deg + 90));
        wall.GetComponent<MoveWall>().ResetSpeed();


    }
    //method from stackoverflow answer by: Gab_Ris at: 
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
