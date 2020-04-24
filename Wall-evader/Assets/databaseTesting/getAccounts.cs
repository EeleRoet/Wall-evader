using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

// UnityWebRequest.Get example

// Access a website and use UnityWebRequest.Get to download a page.
// Also try to download a non-existing page. Display the error.

public class getAccounts : MonoBehaviour
{
    public string[] highscores;

    void Start()
    {
        // A correct website page.
        StartCoroutine(GetRequest("https://oege.ie.hva.nl/~ottensj1/getHighscores.php"));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                highscores = webRequest.downloadHandler.text.Split(char.Parse(" "));
                
                foreach (string highscore in highscores)
                {
                    //Debug.Log(highscore);
                }
            }
        }
    }
}