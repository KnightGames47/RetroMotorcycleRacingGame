using UnityEngine;

public interface IGameState
{
    public void EnterState();

    public void ProcessUpdate();

    public void ExitState();
}
