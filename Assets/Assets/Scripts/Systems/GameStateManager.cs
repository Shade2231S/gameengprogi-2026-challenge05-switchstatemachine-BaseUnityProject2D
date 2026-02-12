using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

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
        PauseMenu
    }
    public GameState currentState { get; private set; }
    public GameState previousState { get; private set; }
    [Header("Debug Only")]
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
        previousActiveState = currentActiveState.ToString();
        currentActiveState = previousActiveState.ToString();
        OnGameStateChanged(previousState, currentState);
    }
    public void OnGameStateChanged(GameState previousstate,GameState newstate)
    {
        switch (newstate)
        {
            case GameState.None:
                Debug.Log("this should not show up");
                    return;
            case GameState.Init:
                Time.timeScale = 0;
                SetState(GameState.MainMenu);

                Debug.Log("Changed to Init");
             break;
            case GameState.MainMenu:
                Time.timeScale = 0;
                UImanager.ShowMainMenu();

                Debug.Log("Changed to MainMenu");
             break;
            case GameState.Gameplay:
                Time.timeScale = 1;
                UImanager.ShowGameplayUI();
                Debug.Log("Changed to Gameplay");         
             break;
            case GameState.PauseMenu:
                Time.timeScale = 0;
                UImanager.ShowPausedUI();

                Debug.Log("Changed to PauseMenu");
             break;
            default:
             break;
        }
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(currentState == GameState.MainMenu)
            {
                SetState(GameState.Gameplay);
                    return;
            }
            else if(currentState == GameState.Gameplay)
            {
                SetState(GameState.PauseMenu);
                   return;
            }
            else if(currentState == GameState.PauseMenu)
            {
                SetState(GameState.Init);
                  return;
            }
        }
    }
    public void StartGame()
    {
        SetState(GameState.Gameplay);
    }
    public void Pause()
    {
        if(currentState == GameState.PauseMenu)
        {
            if (currentState == GameState.Gameplay) return;
            SetState(GameState.Gameplay);
        }
        else if( currentState == GameState.Gameplay) 
        {
            if (currentState == GameState.PauseMenu) return;
            SetState(GameState.PauseMenu);
        }

    }
}
