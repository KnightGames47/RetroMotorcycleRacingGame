using UnityEngine;
using UnityEngine.SceneManagement;

public class TestRaceManager : MonoBehaviour
{
    void Start()
    {
        Racing_GameState currentRace = new Racing_GameState(SceneManager.GetActiveScene().name);
        currentRace.EnterState();
    }
}
