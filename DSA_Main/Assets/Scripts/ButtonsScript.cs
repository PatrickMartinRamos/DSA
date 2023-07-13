using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsScript : MonoBehaviour
{   
    
    public void MainMenuScene()
    {
        SceneManager.LoadScene(2);
    } 
    public void GameScene()
    {
        SceneManager.LoadScene(3);
    }
    public void helpscreen()
    {
        SceneManager.LoadScene(4);
    }
    public void RegisterScene()
    {
        SceneManager.LoadScene(1);
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    public void leaderboardscene()
    {
        SceneManager.LoadScene(6);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("exit");
    }

}
