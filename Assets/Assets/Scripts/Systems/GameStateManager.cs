using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    private UIManager UImanager;
    public int delay = 1;
    public enum GameState
    {
        Init,
        MainMenu,
        Gameplay,
        PauseMenu
    }
    public GameState currentState { get; private set; }
    public GameState previousState { get; private set; }
    [SerializeField] private string currentActiveState;
    [SerializeField] private string previousActiveState;
    private void Start()
    {
        SetState(GameState.Init);
    }
    public void SetState(GameState newstate)
    {
        if (currentState == newstate) return;
        previousState = currentState;
        currentState = newstate;
        currentActiveState = previousActiveState.ToString();
        previousActiveState = currentActiveState.ToString();
    }
    public void OnGameState()
    {

    }
    public void OnGameStateChanged(GameState previousstate,GameState newstate)
    {
        switch (newstate)
        {
            case GameState.Init:
                SetState(GameState.Init);
                Debug.Log("Changed to Init");
             break;
            case GameState.MainMenu:
                UImanager.ShowMainMenu();
                Debug.Log("Changed to MainMenu");
             break;
            case GameState.Gameplay:
                UImanager.ShowGameplayUI();
                Debug.Log("Changed to Gameplay");         
             break;
            case GameState.PauseMenu:
                UImanager.ShowPausedUI();
                Debug.Log("Changed to PauseMenu");
             break;
            default:
             break;
        }
    }
}
