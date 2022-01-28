using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameState
{
    menu,
    inGame,
    winGame,
    gameOver
}
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameState currentGameState = GameState.menu;
    public Canvas menuCanvas;
    public Canvas inGameCanvas;
    public Canvas gameOverCanvas;
    public Canvas winGameCanvas;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        currentGameState = GameState.menu;
    }

    public void StartGame()
    {
        CharacterController2D.instance.StartGame();
        SetGameState(GameState.inGame);
    }

    public void GameOver()
    {
        SetGameState(GameState.gameOver);
    }

    public void WinGame()
    {
        SetGameState(GameState.winGame);
    }

    public void BackToMenu()
    {
        SetGameState(GameState.menu);
    }

    void SetGameState(GameState newGameState)
    {
        if (newGameState == GameState.menu)
        {
            // set up unity scene for menu state
            menuCanvas.enabled = true;
            inGameCanvas.enabled = false;
            winGameCanvas.enabled = false;
            gameOverCanvas.enabled = false;
        }

        else if (newGameState == GameState.inGame)
        {
            //set up Unity scene for inGame state
            menuCanvas.enabled = false;
            inGameCanvas.enabled = true;
            winGameCanvas.enabled = false;
            gameOverCanvas.enabled = false;
        }

        else if (newGameState == GameState.gameOver)
        {
            //set up Unity scene for gameOver state
            menuCanvas.enabled = false;
            inGameCanvas.enabled = false;
            gameOverCanvas.enabled = true;
            winGameCanvas.enabled = false;
        }

        else if (newGameState == GameState.winGame)
        {

            //set up Unity scene for winGame state
            menuCanvas.enabled = false;
            inGameCanvas.enabled = false;
            winGameCanvas.enabled = true;
            gameOverCanvas.enabled = false;
        }

        currentGameState = newGameState;
    }

    
}
