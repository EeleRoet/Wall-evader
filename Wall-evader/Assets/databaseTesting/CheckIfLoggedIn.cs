using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfLoggedIn : MonoBehaviour
{
    // Update is called once per frame
    void Start()
    {
        print(string.IsNullOrEmpty(PlayerPrefs.GetString("Login")));

        if (!PlayerPrefs.HasKey("Login"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("database_testing");
        }
    }
}
