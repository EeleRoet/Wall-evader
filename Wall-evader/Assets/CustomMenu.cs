using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;

public class CustomMenu : MonoBehaviour
{

    public float UnlockScore = ScoreScript.score;
    public Button greenButton;
    public Button blueButton;
    public Button orangeButton;
    public Button pinkButton;
    public Button greenSButton;
    public Button blueSButton;
    public Button orangeSButton;
    public Button pinkSButton;
    public Button goldButton;


    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        Debug.Log("werek");
    }

    public void openMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
        Debug.Log("pls");
    }

    public void UnlockedCustom()
        {



        if (UnlockScore >= 20)
        {

            greenButton.interactable = true;

        }

        if (UnlockScore >= 50)
        {

            blueButton.interactable = true;

        }

        if (UnlockScore >= 100)
        {

            orangeButton.interactable = true;

        }

        if (UnlockScore >= 200)
        {

            pinkButton.interactable = true;

        }

        if (UnlockScore >= 500)
        {

            greenSButton.interactable = true;

        }

        if (UnlockScore >= 1000)
        {

            blueSButton.interactable = true;

        }

        if (UnlockScore >= 2000)
        {

            orangeSButton.interactable = true;

        }

        if (UnlockScore >= 5000)
        {

            pinkSButton.interactable = true;

        }

        if (UnlockScore >= 10000)
        {

            goldButton.interactable = true;

        }

    }


}
