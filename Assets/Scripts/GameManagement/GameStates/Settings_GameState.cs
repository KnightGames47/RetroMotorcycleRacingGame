using UnityEngine;

public class Settings_GameState : IGameState
{
    private SettingsMenu_Presenter _presenter;

    public GameStates StateType => GameStates.SETTINGS;

    public void EnterState()
    {
        _presenter = new SettingsMenu_Presenter();
        _presenter.Init();
    }

    public void ExitState()
    {
        _presenter.Cleanup();
    }

    public void ProcessUpdate()
    {
    }
}
