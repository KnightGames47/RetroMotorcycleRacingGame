using UnityEngine;

public class Customization_GameState : IGameState
{
    private CustomizationMenu_Presenter _presenter;

    public GameStates StateType => GameStates.CUSTOMIZATION;

    public void EnterState()
    {
        _presenter = new CustomizationMenu_Presenter();
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
