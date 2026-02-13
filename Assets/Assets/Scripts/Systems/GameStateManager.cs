using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameStateManager : MonoBehaviour
{
    private UIManager UImanager;
    private ServiceHub serviceHub;
    public enum GameState
    {
        None,
        Init,
        MainMenu,
        Gameplay,
        PauseMenu,
        GameOver,
        Options
    }
    public GameState previousState { get; private set; }
    public GameState currentState { get; private set; }
    [Header("Debug (Read Only)")]
    [SerializeField] private string currentActiveState;
    [SerializeField] private string previousActiveState;
    private void Start()
    {
        serviceHub = ServiceHub.Instance;
        UImanager = serviceHub.uIManager;
        SetState(GameState.Init);
    }
    public void SetState(GameState newstate)
    {
        if (currentState == newstate) return;
        previousState = currentState;
        currentState = newstate;
        previousActiveState = previousState.ToString();
        currentActiveState = currentState.ToString();
        OnGameStateChanged(currentState, currentState);
    }
    public void OnGameStateChanged(GameState previousstate,GameState newstate)
    {
        switch (newstate)
        {
            case GameState.None:
                Debug.Log("this should not show up");
                    return;
            case GameState.Init:
                Debug.Log("Changed to Init");
                Time.timeScale = 0;
                SetState(GameState.MainMenu);
             break;
            case GameState.MainMenu:
                Debug.Log("Changed to MainMenu");
                Time.timeScale = 0;
                UImanager.ShowMainMenu();
             break;
            case GameState.Gameplay:
                Debug.Log("Changed to Gameplay");    
                Time.timeScale = 1;
                UImanager.ShowGameplayUI();
             break;
            case GameState.PauseMenu:
                Debug.Log("Changed to Paused");
                Time.timeScale = 0;
                UImanager.ShowPausedUI();
             break;
            case GameState.GameOver:
                Debug.Log("Changed to GameOver");
                Time.timeScale = 0;
                UImanager.ShowGameOverUI();
               break;
            case GameState.Options:
                Time.timeScale = 0;
                UImanager.ShowOptionsUi();
               break;
            default:
             break;
        }
    }
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetGameOver();
        }
    }
    public void StartGame()
    {
        Debug.Log("Started");
        SetState(GameState.Gameplay);
    }
    public void SetGameOver()
    {
        if(currentState != GameState.Gameplay)
        {

        }
        else if(currentState == GameState.Gameplay)
        {
            Debug.Log("GameOver");
            SetState(GameState.GameOver);
        }
    }
    public void TogglePause()
    {
        if(currentState == GameState.PauseMenu)
        {
            Debug.Log("UnPaused");
            if (currentState == GameState.Gameplay) return;
            SetState(GameState.Gameplay);
        }
        else if( currentState == GameState.Gameplay) 
        {
            Debug.Log("Paused");
            if (currentState == GameState.PauseMenu) return;
            SetState(GameState.PauseMenu);
        }
    }
    public void BackButton()
    {
        SetState(previousState);
    }
    public void MainMenu()
    {
        Debug.Log("MainMenu");
        SetState(GameState.MainMenu);
    }
    public void OptionsButton()
    {
        SetState(GameState.Options);
    }
    public void quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
