using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject GameplayUI;
    [SerializeField] private GameObject PausedUI;
    [SerializeField] private GameObject GAMEOVERUI;
    [SerializeField] private GameObject OptionsUI;
    public void ShowMainMenu()
    {  
        HideAllUI();
        MainMenu.SetActive(true);
    }
    public void ShowGameplayUI()
    {
        HideAllUI();

        GameplayUI.SetActive(true);
    }
    public void ShowPausedUI()
    {
        HideAllUI();
        GameplayUI.SetActive(true);
        PausedUI.SetActive(true);
    }
    public void ShowGameOverUI()
    {
        HideAllUI();

        GAMEOVERUI.SetActive(true);
    }
    public void ShowOptionsUi()
    {
        HideAllUI();
        OptionsUI.SetActive(true);
    }
    public void HideAllUI()
    {
        MainMenu.SetActive(false);
        GameplayUI.SetActive(false);
        PausedUI.SetActive(false);
        GAMEOVERUI.SetActive(false);
        OptionsUI.SetActive(false);
    }
}
