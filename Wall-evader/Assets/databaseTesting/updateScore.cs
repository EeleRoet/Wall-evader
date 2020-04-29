using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class updateScore : MonoBehaviour
{
    float dbScore;
    public void Start()
    {
        print("test");
        StartCoroutine(selectHighscore());
    }

    public void Update()
    {
        if (ScoreScript.score > dbScore)
        {
            StartCoroutine(updateHighscore());
            dbScore = ScoreScript.score;
        }
    }


    IEnumerator selectHighscore()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", PlayerPrefs.GetString("Login"));

        using (UnityWebRequest www = UnityWebRequest.Post("https://oege.ie.hva.nl/~ottensj1/selectHighscore.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                dbScore = int.Parse(www.downloadHandler.text);
            }
        }
    }

    IEnumerator updateHighscore()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", PlayerPrefs.GetString("Login"));
        form.AddField("score", ScoreScript.score.ToString());

        using (UnityWebRequest www = UnityWebRequest.Post("https://oege.ie.hva.nl/~ottensj1/updateScore.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                print(PlayerPrefs.GetString("Login") + "has a highscore of: " + ScoreScript.score.ToString());
            }
        }
    }
}
