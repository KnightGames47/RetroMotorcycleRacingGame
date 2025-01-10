using UnityEngine;

public class MainMenu_Presenter
{
    private MainMenu_View _view;

    public void Init()
    {
        _view = Object.FindFirstObjectByType<MainMenu_View>();
        _view.EnableMainMenuPanel();

        _view.SetPlayButtonListeners(OnPlayClicked);
        _view.SetCustomizeButtonListeners(OnCustomizeClicked);
        _view.SetSettingsButtonListeners(OnSettingsClicked);
        _view.SetCreditsButtonListeners(OnCreditsClicked);
        _view.SetQuitButtonListeners(OnQuitClicked);
    }

    public void Cleanup()
    {
        _view.DisableMainMenuPanel();
        _view.ReleaseAllButtonListeners();
    }

    private void OnPlayClicked()
    {
        GameStateManager.Instance.TransitionToState(new LevelSelect_GameState());
    }

    private void OnCustomizeClicked()
    {
        //Open customization menu
    }

    private void OnSettingsClicked()
    {
        //TODO: Open the settings menu
    }

    private void OnCreditsClicked()
    {
        //TODO: Open the credits screen
    }

    private void OnQuitClicked()
    {
        Application.Quit();
    }
}
