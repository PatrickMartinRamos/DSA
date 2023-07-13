using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

public class FinalScore : MonoBehaviour
{
    public static FinalScore instance;
    public TextMeshProUGUI scoreText;

    //private LogInScript ls = new LogInScript();

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        // Retrieve the last score from PlayerPrefs
        int lastScore = PlayerPrefs.GetInt("LastScore", 0);

        // Display the last score on the UI
        scoreText.text = "Your Score: " + lastScore.ToString();
        string playername = LogInScript.Instance.GetPlayerName();
        StartCoroutine(Main.Instance.Web.UpdateScore(lastScore, playername));

    }
}
