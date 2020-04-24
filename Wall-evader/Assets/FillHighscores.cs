using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class FillHighscores : MonoBehaviour
{
    [SerializeField] private getAccounts accounts;

    List<Text> tabelText = new List<Text>();

    // Start is called before the first frame update
    void Start()
    {
        //scores = GetComponentsInChildren<Text>().ToList();

        StartCoroutine(wait());

        print(tabelText.Count);
        print(accounts.highscores.Length);
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < tabelText.Count; i++)
        {
            tabelText[i].text = accounts.highscores[i];
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(.001f);

        foreach (Text text in GetComponentsInChildren<Text>(true))
        {
            if (text.tag != "rank")
            {
                tabelText.Add(text);
            }
        }
    }
}
