using UnityEngine;

public class SettingsMenu_Presenter
{
    private SettingsMenu_Model _model;
    private SettingsMenu_View _view;

    public void Init()
    {
        _model = new SettingsMenu_Model();
        _view = Object.FindFirstObjectByType<SettingsMenu_View>();
        _view.EnableSettingsPanel();

        _view.SetBackButtonListeners(OnBackClicked);
    }

    public void Cleanup()
    {
        _view.DisableSettingsPanel();
        _view.ReleaseAllButtonListeners();
    }

    private void OnBackClicked()
    {
        GameStateManager.Instance.TransitionToState(new MainMenu_GameState());
    }
}
