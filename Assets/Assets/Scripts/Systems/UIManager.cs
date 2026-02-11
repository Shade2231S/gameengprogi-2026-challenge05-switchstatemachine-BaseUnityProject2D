using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject GameplayUI;
    [SerializeField] private GameObject PausedUI;
    public void ShowMainMenu()
    {       
        GameplayUI.SetActive(false);
        PausedUI.SetActive(false);
        MainMenu.SetActive(true);
    }
    public void ShowGameplayUI()
    {
        MainMenu.SetActive(false);
        PausedUI.SetActive(false);
        GameplayUI.SetActive(true);
    }
    public void ShowPausedUI()
    {
        MainMenu.SetActive(false);
        GameplayUI.SetActive(false);
        PausedUI.SetActive(true);
    }
}
