using UnityEngine;

public class CreditsMenu_GameState : IGameState
{
    private CreditsMenu_Presenter _presenter;

    public GameStates StateType => GameStates.CREDITS;

    public void EnterState()
    {
        _presenter = new CreditsMenu_Presenter();
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
