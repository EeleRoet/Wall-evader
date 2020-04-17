using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dbStuff : MonoBehaviour
{
    public InputField nameField;

    public Button submit;

    private string login;

    public void Start()
    {
        login = "Player has logged in before";

    }

    public void CallRegister()
    {
        StartCoroutine(Register());
    }

    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);

        WWW www = new WWW("http://localhost/sqlconnect/register.php", form);
        yield return www;
        Debug.Log("user created successfully.");
        LogIn();
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void VerifyInputs()
    {
        submit.interactable = (nameField.text.Length >= 2);
    }

    public void LogIn()
    {
        PlayerPrefs.SetString("Login", login);
    }
}
