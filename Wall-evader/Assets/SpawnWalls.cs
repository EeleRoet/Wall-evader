using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWalls : MonoBehaviour
{
    [SerializeField] private GameObject wallPrefab;
    [SerializeField] private Transform spawnPosition;
    private float unitToForm = 0.8f; //converts in-script units to formula integers.
    [SerializeField] private GenerateData dataScript;


    // Start is called before the first frame update
    void Start()
    {
        dataScript.GenerateNewData();
        SpawnWall(wallPrefab, dataScript.hellingsGetal, dataScript.startgetal);
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(wallPrefab, spawnPosition.position, Quaternion.identity);
        }
        
    }

    public void SpawnWall(GameObject wallPrefab,float helling, float start)
    {
        Debug.Log(start);
        GameObject newWall = Instantiate(wallPrefab, spawnPosition.position + (Vector3.up * (start * unitToForm)), Quaternion.identity);
        GetFirstChildren(newWall.transform)[0].Rotate(Vector3.forward * (Mathf.Atan(helling) * Mathf.Rad2Deg + 90));
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
