using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ColorSelector : MonoBehaviour
{

    public GameObject player;
    public ColorChange colorChange;





    public void DefaultPlayer()
    {

        resetPlayerColor();
        colorChange.defaultColor = true;

    }

    public void GreenPlayer()
    {

        resetPlayerColor();
        colorChange.greenColor = true;
        Debug.Log("green");

    }

    public void BluePlayer()
    {

        resetPlayerColor();
        colorChange.blueColor = true;

    }

    public void OrangePlayer()
    {

        resetPlayerColor();
        colorChange.orangeColor = true;

    }
    public void PinkPlayer()
    {

        resetPlayerColor();
        colorChange.pinkColor = true;

    }

    public void GreenSPlayer()
    {

        resetPlayerColor();
        colorChange.greenSColor = true;

    }

    public void BlueSPlayer()
    {

        resetPlayerColor();
        colorChange.blueSColor = true;

    }

    public void OrangeSPlayer()
    {

        resetPlayerColor();
        colorChange.orangeSColor = true;

    }

    public void PinkSPlayer()
    {

        resetPlayerColor();
        colorChange.pinkSColor = true;

    }

    public void GoldPlayer()
    {

        resetPlayerColor();
        colorChange.goldColor = true;

    }

    public void resetPlayerColor()
    {

        colorChange.defaultColor = false;
        colorChange.greenColor = false;
        colorChange.blueColor = false;
        colorChange.orangeColor = false;
        colorChange.pinkColor = false;
        colorChange.greenSColor = false;
        colorChange.blueSColor = false;
        colorChange.orangeSColor = false;
        colorChange.pinkSColor = false;
        colorChange.goldColor = false;

}



}
