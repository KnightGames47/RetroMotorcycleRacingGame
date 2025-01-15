using UnityEngine;

public class CreditsMenu_Presenter
{
    private CreditsMenu_View _view;

    public void Init()
    {
        _view = Object.FindFirstObjectByType<CreditsMenu_View>();
        _view.EnableCreditsPanel();
        _view.SetBackButtonListeners(OnBackButtonClick);
    }

    public void Cleanup()
    {
        _view.DisableCreditsPanel();
        _view.ReleaseAllButtons();
    }

    private void OnBackButtonClick()
    {
        GameStateManager.Instance.TransitionToState(new MainMenu_GameState());
    }
}
