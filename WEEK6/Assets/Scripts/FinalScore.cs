using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    //private LogInScript ls = new LogInScript();

    // Start is called before the first frame update
    void Start()
    {
        // Retrieve the last score from PlayerPrefs
        int lastScore = PlayerPrefs.GetInt("LastScore", 0);

        // Display the last score on the UI
        scoreText.text = "Your Score: " + lastScore.ToString();
        string playername = LogInScript.Instance.GetPlayerName();
        StartCoroutine(Main.Instance.Web.UpdateScore(lastScore, playername));
    }



}
