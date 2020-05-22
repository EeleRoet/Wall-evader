using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class dbStuff : MonoBehaviour
{
    public InputField nameField;

    public Button submit;

    public Text warningText;

    private string login;

    public void Start()
    {
    }

    public void CallRegister()
    {
        StartCoroutine(Register());
    }

    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);

        using (UnityWebRequest www = UnityWebRequest.Post("https://oege.ie.hva.nl/~ottensj1/register.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {

                string responseText = www.downloadHandler.text;

                if (responseText.StartsWith("Account"))
                {
                    LogIn();
                    SceneManager.LoadScene("MainMenu");
                }
                else
                {
                    print(www.downloadHandler.text);
                    if (www.downloadHandler.text.Contains("exists"))
                    {
                        warningText.gameObject.SetActive(true);
                    }
                }
            }
        }
    }

    public void VerifyInputs()
    {
        submit.interactable = nameField.text.Length >= 2;
    }

    public void LogIn()
    {
        login = nameField.text;
        PlayerPrefs.SetString("Login", login);
    }
}
