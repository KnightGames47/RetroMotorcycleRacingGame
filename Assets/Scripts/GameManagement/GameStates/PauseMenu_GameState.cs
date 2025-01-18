using UnityEngine;

public class PauseMenu_GameState : IGameState
{
    private PauseMenu_Presenter _presenter;

    GameStates IGameState.StateType => GameStates.PAUSE;
    private Racing_GameState currentRace;

    public PauseMenu_GameState(Racing_GameState race)
    {
        currentRace = race;
    }
    
    public void EnterState()
    {
        _presenter = new PauseMenu_Presenter();
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
