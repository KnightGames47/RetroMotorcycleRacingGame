using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu_Presenter
{
    private PauseMenu_View _pauseMenuView;
    //private IngameSettingsMenu_View _inGameSettingsView;

    public void Init()
    {
        _pauseMenuView = Object.FindFirstObjectByType<PauseMenu_View>();
        _pauseMenuView.EnablePauseMenuPanel();

        //Actually handling the stopping of the game:
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void Cleanup()
    {
        _pauseMenuView.DisablePauseMenuPanel();
        _pauseMenuView.ReleaseAllButtonListeners();

        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnRestartClicked()
    {
        //reload the current scene
        GameStateManager.Instance.TransitionToState(new Racing_GameState(SceneManager.GetActiveScene().name));
    }

    private void OnResumeClicked()
    {
        //GameStateManager.Instance.TransitionToState(currentRace);
    }

    private void OnSettingsClicked()
    {
        //open up the in-game settings menu
    }

    private void OnQuitClicked()
    {
        //quit the scene, and enter level select menu
    }
}
