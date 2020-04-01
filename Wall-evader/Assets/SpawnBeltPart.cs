using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBeltPart : MonoBehaviour
{
    [SerializeField] private GameObject beltPrefab;
    [SerializeField] private Transform spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        //spawn start belt pieces along whole conveyor
        InvokeRepeating("spawnBeltPiece", 0f, 0.8f);
    }

    private void Update()
    {
        
    }

    public void spawnBeltPiece()//gets called periodically when new belt piece is required.
    {
        GameObject newWall = Instantiate(beltPrefab, spawnPosition);
        Debug.Log("oi");
    }
}
