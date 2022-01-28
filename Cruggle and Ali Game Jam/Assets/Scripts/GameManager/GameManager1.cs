using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager1 : MonoBehaviour
{
    public static GameManager1 instance;
    public Camera mainCamera;

    public Canvas controlsCanvas;
    public Canvas gameOverCanvas;
    public Canvas gameWinCanvas;

    private bool controlsEnabled = false;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {

    }

    public void PlayerWin()
    {
        CharacterController2D.instance.playerHasWon = true;
        gameWinCanvas.enabled = true;

    }
    public void GameOver()
    {
        mainCamera.GetComponent<CameraFollow>().enabled = false;
        gameOverCanvas.enabled = true;


    }

    public void Retry()
    {
        {
            Debug.Log("retry");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
        }
    }

    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }

    public void BringUpControls()
    {
        

        controlsEnabled = !controlsEnabled;

        if (controlsEnabled == true)
        {
            controlsCanvas.enabled = true;
        }

        else
        {
            controlsCanvas.enabled = false;
        }
    }
}