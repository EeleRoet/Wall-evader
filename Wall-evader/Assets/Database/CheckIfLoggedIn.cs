using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfLoggedIn : MonoBehaviour
{
    // Update is called once per frame
    void Start()
    {
        Time.timeScale = 1.0f;
        print(string.IsNullOrEmpty(PlayerPrefs.GetString("Login")));

        print(PlayerPrefs.GetString("Login", "nothing found"));

        if (!PlayerPrefs.HasKey("Login"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Registratie");
        }
    }
}
