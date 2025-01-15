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
        GameStateManager.Instance.TransitionToState(new Customization_GameState());
    }

    private void OnSettingsClicked()
    {
        GameStateManager.Instance.TransitionToState(new Settings_GameState());
    }

    private void OnCreditsClicked()
    {
        GameStateManager.Instance.TransitionToState(new CreditsMenu_GameState());
    }

    private void OnQuitClicked()
    {
        Application.Quit();
    }
}
