using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using static UnityEngine.EventSystems.EventTrigger;

public class WebScript : MonoBehaviour
{


    void Start()
    {
        // A correct website page.
        //StartCoroutine(GetDate("http://localhost/unityBackend/GetDate.php"));
        //StartCoroutine(GetUser("http://localhost/unityBackend/GetUser.php"));
        //StartCoroutine(Login_s("patrick", "123123"));
    }

    IEnumerator GetDate(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    break;
            }
        }
    }
    public IEnumerator GetUser(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    break;
            }
        }
    }

    public IEnumerator Login_s(string player_name, string player_password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", player_name);
        form.AddField("loginPass", player_password);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/unityBackend/Login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                // Check the response from the PHP script
                string responseText = www.downloadHandler.text;

                if (responseText.Contains("log in successfully"))
                {
                    Debug.Log("Login successful");
                    // Perform actions for a successful login
                    SceneManager.LoadScene(0);
                    Debug.Log(player_name);



                }
                else if (responseText.Contains("wrong credentials"))
                {
                    Debug.Log("Wrong credentials");
                    // Perform actions for wrong credentials
                }
                else if (responseText.Contains("user does not exist"))
                {
                    Debug.Log("User does not exist");
                    // Perform actions for non-existent user
                }
            }
        }
    }



    public IEnumerator RegisterUser(string player_name, string player_password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", player_name);
        form.AddField("loginPass", player_password);


        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/unityBackend/RegisterUser.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);

            }
        }
    }

    public IEnumerator UpdateScore(int player_score, string player_name)
    {
        WWWForm form = new WWWForm();
        form.AddField("playerScore", player_score);
        form.AddField("loginUser", player_name);



        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/unityBackend/UpdateScore.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Score updated successfully!");
                Debug.Log("Response: " + www.downloadHandler.text);

            }
        }
    }

}
