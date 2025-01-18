using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu_Presenter
{
    private PauseMenu_View _pauseMenuView;
    private InGameSettings_View _inGameSettingsView;

    public void Init()
    {
        _pauseMenuView = Object.FindFirstObjectByType<PauseMenu_View>();
        _pauseMenuView.EnablePauseMenuPanel();

        _pauseMenuView.SetRestartButtonListeners(OnRestartClicked);
        _pauseMenuView.SetResumeButtonListeners(OnResumeClicked);
        _pauseMenuView.SetSettingsButtonListeners(OnSettingsClicked);
        _pauseMenuView.SetQuitButtonListeners(OnQuitClicked);

        //Ingame settings:
        _inGameSettingsView = Object.FindFirstObjectByType<InGameSettings_View>();
        _inGameSettingsView.SetBackButtonListeners(OnSettings_BackButtonClicked);

        //Actually handling the stopping of the game:
        Time.timeScale = 0;
    }

    public void Cleanup()
    {
        _pauseMenuView.DisablePauseMenuPanel();
        _pauseMenuView.ReleaseAllButtonListeners();

        _inGameSettingsView.DisableSettingsPanel();
        _inGameSettingsView.ReleaseAllButtonListeners();

        Time.timeScale = 1;
    }

    private void OnRestartClicked()
    {
        //reload the current scene
        GameStateManager.Instance.TransitionToState(new Racing_GameState(SceneManager.GetActiveScene().name));
        GameStateManager.Instance.ExitPauseState();
    }

    private void OnResumeClicked()
    {
        GameStateManager.Instance.ExitPauseState();
    }

    private void OnSettingsClicked()
    {
        //open up the in-game settings menu
        _pauseMenuView.DisablePauseMenuPanel();
        _inGameSettingsView.EnableSettingsPanel();
    }

    private void OnQuitClicked()
    {
        //quit the scene, and enter level select menu
        GameStateManager.Instance.ExitPauseState();
        GameStateManager.Instance.TransitionToState(new LevelSelect_GameState());
    }


    //Settings stuff:==================================
    private void OnSettings_BackButtonClicked()
    {
        _inGameSettingsView.DisableSettingsPanel();
        _pauseMenuView.EnablePauseMenuPanel();
    }
}
