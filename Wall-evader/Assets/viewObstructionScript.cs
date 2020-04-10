using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class viewObstructionScript : MonoBehaviour
{ 
    public void deactivateObstruction()
    {
        gameObject.active = false;
       
    }

    public void activateObstruction()
    {
        gameObject.active = true;
    }

}
