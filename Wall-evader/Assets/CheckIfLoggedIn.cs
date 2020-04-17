using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfLoggedIn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(PlayerPrefs.HasKey("Login"));
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.HasKey("Login"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
}
