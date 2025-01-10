using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenu_View : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private Button playButton;
    [SerializeField] private Button customizeButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button creditsButton;
    [SerializeField] private Button quitButton;

    public void EnableMainMenuPanel()
    {
        mainMenuPanel.SetActive(true);
    }

    public void DisableMainMenuPanel() 
    { 
        mainMenuPanel.SetActive(false); 
    }

    public void SetPlayButtonListeners(UnityAction action)
    {
        playButton.onClick.AddListener(action);
    }

    public void SetCustomizeButtonListeners(UnityAction action)
    {
        customizeButton.onClick.AddListener(action);
    }

    public void SetSettingsButtonListeners(UnityAction action)
    {
        settingsButton.onClick.AddListener(action);
    }

    public void SetCreditsButtonListeners(UnityAction action)
    {
        creditsButton.onClick.AddListener(action);
    }

    public void SetQuitButtonListeners(UnityAction action)
    {
        quitButton.onClick.AddListener(action);
    }

    public void ReleaseAllButtonListeners()
    {
        playButton?.onClick.RemoveAllListeners();
        customizeButton?.onClick.RemoveAllListeners();
        settingsButton?.onClick.RemoveAllListeners();
        creditsButton?.onClick.RemoveAllListeners();
        quitButton? .onClick.RemoveAllListeners();
    }
}
