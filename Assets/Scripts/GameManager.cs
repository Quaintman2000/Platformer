using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject BackgroundImageGameObject;
    public GameObject TitleTextGameObject;
    public GameObject LostTextGameObject;
    public GameObject WinTextGameObject;
    public GameObject StartButtonGameObject;
    public GameObject QuitButtonGameObject;
    public GameObject RetryButtonGameObject;
    public GameObject SpawnPointGameObject;
    public GameObject PlayerPregabGameObject;
    public int currentScene;

    private Transform camTransform;
    private Transform playerTransform;

    public string gameState;
    public int playerLives = 3;
    public static GameManager instance;
    

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartScreen();
        camTransform = GameObject.Find("Main Camera").gameObject.GetComponent<Transform>();
        playerTransform = GameObject.Find("Player").gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //have the camera follow the player
        camTransform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, camTransform.position.z);
        Debug.Log(gameState);


        //check game states
        if (gameState == "Start Screen")
        {
            //show start screen
            StartScreen();
        }
        else if (gameState == "Game Running")
        {
            //do nothing
        }
        else if (gameState == "Game Lose")
        {
            //show game Lose screen
            GameLose();
        }
        else if (gameState == "Game Win")
        {
            //show game win screen
            GameWin();
        }
        else
        {
            Debug.LogError("Missing game state!");
        }
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
        //display start screen state
        gameState = "Start Screen";
        BackgroundImageGameObject.SetActive(true);
        TitleTextGameObject.SetActive(true);
        LostTextGameObject.SetActive(false);
        WinTextGameObject.SetActive(false);
        StartButtonGameObject.SetActive(true);
        QuitButtonGameObject.SetActive(true);
        RetryButtonGameObject.SetActive(false);
    }
    //change to game run state
    public void GameStart()
    {
        //reset lives to 3
        playerLives = 3;
        
        //display game running state
        gameState = "Game Running";
        BackgroundImageGameObject.SetActive(false);
        TitleTextGameObject.SetActive(false);
        LostTextGameObject.SetActive(false);
        WinTextGameObject.SetActive(false);
        StartButtonGameObject.SetActive(false);
        QuitButtonGameObject.SetActive(false);
        RetryButtonGameObject.SetActive(false);
    }
    //change to game lose state
    public void GameLose()
    {
        //display game lose state
        gameState = "Game Lose";
        BackgroundImageGameObject.SetActive(true);
        TitleTextGameObject.SetActive(false);
        LostTextGameObject.SetActive(true);
        WinTextGameObject.SetActive(false);
        StartButtonGameObject.SetActive(false);
        QuitButtonGameObject.SetActive(true);
        RetryButtonGameObject.SetActive(true);
    }
    //change to game win state
    public void GameWin()
    {
        //display game win state
        gameState = "Game Win";
        BackgroundImageGameObject.SetActive(true);
        TitleTextGameObject.SetActive(false);
        LostTextGameObject.SetActive(true);
        WinTextGameObject.SetActive(false);
        StartButtonGameObject.SetActive(false);
        QuitButtonGameObject.SetActive(true);
        RetryButtonGameObject.SetActive(true);
    }

    public void Respawn()
    {
        if (playerLives == 0)
        {
            gameState = "Game Lose";
        }
        else
        {
            Instantiate(PlayerPregabGameObject, SpawnPointGameObject.transform.position,
                SpawnPointGameObject.transform.rotation);
        }
    }
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
        //SceneManager.LoadScene
    }
}
