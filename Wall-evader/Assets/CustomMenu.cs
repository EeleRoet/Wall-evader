using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CustomMenu : MonoBehaviour
{

    
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



        }


}
