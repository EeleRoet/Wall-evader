using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiateHighscores : MonoBehaviour
{
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject testing = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            testing.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
