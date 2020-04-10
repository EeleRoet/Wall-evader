using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class viewObstructionScript : MonoBehaviour
{
    private bool fadeObstruction;
    private bool obstructionActivated;
    [SerializeField] private Material material;
    private Color color;

    public void start()
    {
        activateObstruction();
        fadeObstruction = false;
        obstructionActivated = false;
    }

    public void Update()
    {
        if(!obstructionActivated )
        {
            activateObstruction();
            obstructionActivated = true;
        }

        if ( fadeObstruction)
        {
             color = material.color;
             color.a -= 0.01f;
             material.color = color;
             if(color.a <= 0)
             {
                 Debug.Log("cheff");
                 fadeObstruction = false;
             }
        }
        
    }

    public void deactivateObstruction()
    {
       fadeObstruction = true;
    }

    public void activateObstruction()
    {
        color = material.color;
        color.a = 1;
        material.color = color;
    }
}
