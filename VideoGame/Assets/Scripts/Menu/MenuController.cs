using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [Header("Menu Game Objects")]
    public GameObject startGameButton;
    public GameObject statisticsButton;
    public GameObject optionsButton;
    public GameObject exitButton;

    void Start()
    {
        //Add listeners
        startGameButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(StartGame);
        statisticsButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(ShowStatistics);
        optionsButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(ShowOptions);
        exitButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(ExitGame);
    }

    void StartGame()
    {
        //Start Game
        SceneManager.LoadScene("GameScene");
    }

    void ShowStatistics()
    {
        //Show Statistics
        Debug.Log("Show Statistics");
    }

    void ShowOptions()
    {
        //Show Options
        Debug.Log("Show Options");
    }

    void ExitGame()
    {
        //Quit the game
        Application.Quit();
    }
}
