using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class instantiateHighscores : MonoBehaviour
{
    [SerializeField] private getAccounts tableData;

    List<Text> ranks = new List<Text>();

    List<Image> masks = new List<Image>();

    int currentRank;

    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(wait());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < (tableData.allScores.Count - 1) / 2; i++)
        {
            GameObject testing = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            testing.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        }

        foreach (Text text in GetComponentsInChildren<Text>(true))
        {
            if (text.tag == "rank")
            {
                ranks.Add(text);
            }
        }

        for (int i = 0; i < (tableData.allScores.Count - 1) / 2; i++)
        {
            ranks[i].text = "#" + (i + 1);
        }

        foreach (Image mask in GetComponentsInChildren<Image>(true))
        {
            if (mask.tag == "HighscoreMask")
            {
                masks.Add(mask);
            }
        }

        currentRank = tableData.allScores.IndexOf(PlayerPrefs.GetString("Login")) / 2;

        masks[currentRank].gameObject.SetActive(true);
    }
}
