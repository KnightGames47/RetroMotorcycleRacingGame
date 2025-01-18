using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PauseMenu_View : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuPanel;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button quitButton;

    public void EnablePauseMenuPanel()
    {
        pauseMenuPanel.SetActive(true);
    }

    public void DisablePauseMenuPanel()
    {
        pauseMenuPanel.SetActive(false);
    }

    public void SetRestartButtonListeners(UnityAction action)
    {
        restartButton.onClick.AddListener(action);
    }

    public void SetResumeButtonListeners(UnityAction action)
    {
        resumeButton.onClick.AddListener(action);
    }

    public void SetSettingsButtonListeners(UnityAction action)
    {
        settingsButton.onClick.AddListener(action);
    }

    public void SetQuitButtonListeners(UnityAction action)
    {
        quitButton.onClick.AddListener(action);
    }

    public void ReleaseAllButtonListeners()
    {
        restartButton?.onClick.RemoveAllListeners();
        resumeButton?.onClick.RemoveAllListeners();
        settingsButton?.onClick.RemoveAllListeners();
        quitButton?.onClick.RemoveAllListeners();
    }
}
