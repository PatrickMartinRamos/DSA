using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogInScript : MonoBehaviour
{
    public static LogInScript Instance;
    public InputField player_nameInput;
    public InputField player_passwordInput;
    public Button LogInButton;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        LogInButton.onClick.AddListener(() =>
        {
            StartCoroutine(Main.Instance.Web.Login_s(player_nameInput.text, player_passwordInput.text));
        });
    }

    public string GetPlayerName()
    {
        return player_nameInput.text;
    }
}