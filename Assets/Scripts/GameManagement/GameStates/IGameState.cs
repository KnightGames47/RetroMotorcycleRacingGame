using UnityEngine;

public interface IGameState
{
    public GameStates StateType { get; }
    public void EnterState();

    public void ProcessUpdate();

    public void ExitState();
}
