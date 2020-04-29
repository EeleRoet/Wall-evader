using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class FillHighscores : MonoBehaviour
{
    [SerializeField] private getAccounts accounts;

    List<Text> tabelText = new List<Text>();

    private int playerRank;

    // Start is called before the first frame update
    void Start()
    {
        print(PlayerPrefs.GetString("Login", "nothing found"));
        StartCoroutine(wait());
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < tabelText.Count; i++)
        {
            tabelText[i].text = accounts.allScores[i];
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.6f);

        foreach (Text text in GetComponentsInChildren<Text>(true))
        {
            if (text.tag != "rank")
            {
                tabelText.Add(text);
            }
        }
        ScrollToPlayer();
    }

    public void ScrollToPlayer()
    {
        playerRank = (accounts.allScores.IndexOf(PlayerPrefs.GetString("Login", "nothing found")) + 2) / 2;
        this.transform.position = new Vector3(540, 100.1f * playerRank, 0);
    }
}
