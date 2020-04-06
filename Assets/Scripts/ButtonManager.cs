using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    //quits the game
    public void Quit()
    {
        //quit game
        Application.Quit();
    }
    //shows the start screen state
    public void StartScreen()
    {
        //load main menu
        GameManager.instance.currentScene = 0;
        GameManager.instance.LoadLevel(GameManager.instance.currentScene);
    }
    //change to game run state
    public void GameStart()
    {
        //reset lives to 3
        GameManager.instance.playerLives = 3;

        //display game running state

        GameManager.instance.LoadNextScene();

    }
    //change to game lose state
    public void GameLose()
    {
        //go to lose scene
        GameManager.instance.currentScene = 5;
        GameManager.instance.LoadLevel(GameManager.instance.currentScene);
    }
    //change to game win state
    public void GameWin()
    {
        //return to win scene
        GameManager.instance.currentScene = 4;
        GameManager.instance.LoadLevel(GameManager.instance.currentScene);

    }
}
