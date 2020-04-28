using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

// UnityWebRequest.Get example

// Access a website and use UnityWebRequest.Get to download a page.
// Also try to download a non-existing page. Display the error.

public class getAccounts : MonoBehaviour
{
    public List<string> allScores = new List<string>();

    public List<int> result = new List<int>();

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
                allScores = webRequest.downloadHandler.text.Split(char.Parse(" ")).ToList();
            }
        }
    }
}