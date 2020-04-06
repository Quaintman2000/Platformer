using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    public GameObject SpawnPointGameObject;
    public GameObject PlayerPregabGameObject;


    private Transform camTransform;
    public Transform playerTransform;

    public string gameState;
    public int playerLives = 3;
    public static GameManager instance;
    public int currentScene;
    public int playerScore = 0;

    void Awake()
    {
        //if theres no gamemanager
        if (instance == null)
        {
            //set this gameobject as the game manager
            instance = this;
            //set this to not be destroyed when loading scenes
            DontDestroyOnLoad(gameObject);

        }
        //if there is already game manager
        else
        {
            Destroy(this.gameObject);
        }

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {



        ////check game states
        //if (gameState == "Start Screen")
        //{
        //    //show start screen
        //    StartScreen();
        //}
        //else if (gameState == "Game Running")
        //{
        //    // do nothin
        //}
        //else if (gameState == "Game Lose")
        //{
        //    //show game Lose screen
        //    GameLose();
        //}
        //else if (gameState == "Game Win")
        //{
        //    //show game win screen
        //    GameWin();
        //}
        //else
        //{
        //    Debug.LogError("Missing game state!");
        //}
    }

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
        currentScene = 0;
        LoadLevel(currentScene);
    }
    //change to game run state
    public void GameStart()
    {
        //reset lives to 3
        playerLives = 3;

        //display game running state

        GameManager.instance.LoadNextScene();

    }
    //change to game lose state
    public void GameLose()
    {
        //go to lose scene
        currentScene = 5;
        LoadLevel(currentScene);
    }
    //change to game win state
    public void GameWin()
    {
        //return to win scene
        currentScene = 4;
        LoadLevel(currentScene);

    }
    //respawns the player
    public void Respawn()
    {
        //if the player runs out of lives
        if (playerLives == 0)
        {
            //set the state to game lose
            GameLose();
        }
        //if the player still has lives left
        else
        {
            //spawn the player at the desired spawn point
            Instantiate(PlayerPregabGameObject, SpawnPointGameObject.transform.position,
                SpawnPointGameObject.transform.rotation);
        }
    }
    /// <summary>
    /// Loads the desired scene by name.
    /// </summary>
    /// <param name="levelToLoad">Name of the level to load</param>
    public void LoadLevel(string levelToLoad)
    {
        //load desired lvl by name
        SceneManager.LoadScene(levelToLoad);
        //add 1 to current scene
        currentScene++;
    }
    public void LoadLevel(int indexToLoad)
    {
        //load desired level by index
        SceneManager.LoadScene(indexToLoad);
        //change current scene # to the scene #
        currentScene = indexToLoad;
    }
    //loads the next scene
    public void LoadNextScene()
    {
        //loads the scene right after the current one
        SceneManager.LoadScene(currentScene += 1);
    }
}
