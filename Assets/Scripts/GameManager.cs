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
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(this.gameObject);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        gameState = "Start Screen";
        
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

    public void Respawn()
    {
        if (playerLives == 0)
        {

            GameLose();
        }
        else
        {
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
        SceneManager.LoadScene(levelToLoad);
        currentScene++;
    }
    public void LoadLevel(int indexToLoad)
    {
        SceneManager.LoadScene(indexToLoad);
        currentScene = indexToLoad;
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentScene += 1);
    }
}
