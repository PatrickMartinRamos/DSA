using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class leaderBoard : MonoBehaviour
{
    

    public TextMeshProUGUI leaderBoards;
    public TextMeshProUGUI thePlayer;
    public TextMeshProUGUI thePlayerScore;

    public void Start()
    {
        StartCoroutine(GetUser("http://localhost/unityBackend/GetUser.php"));
       
    }

    public IEnumerator GetUser(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length -1;

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
                    string responseData = webRequest.downloadHandler.text;
                    Debug.Log(pages[page] + ":\nReceived: " + responseData);
                    leaderBoards.text = responseData;

                    //display name
                    string playername = LogInScript.Instance.GetPlayerName();
                    thePlayer.text = "Your Name: " + playername;                
                    break;
            }
        }
    }


}
