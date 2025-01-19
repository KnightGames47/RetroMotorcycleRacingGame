using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Racing_GameState : IGameState
{
    public RaceManager raceManager {  get; private set; }

    public GameStates StateType => GameStates.RACING;

    private string sceneToOpen;
    private UnityEvent sceneLoaded;

    //This is eventually going to contain a SO for the level data.
    public Racing_GameState(string sceneName)
    {
        //we need to fill the information
        sceneToOpen = sceneName;
    }

    public async void EnterState()
    {
        GameStateManager.Instance?.loadingScreen.EnableLoadScreen();
        if(SceneManager.GetActiveScene().name != sceneToOpen) 
            await SceneManager.LoadSceneAsync(sceneToOpen);
        Cursor.lockState = CursorLockMode.Locked;
        raceManager = new RaceManager();
        raceManager.Init();
        GameStateManager.Instance?.loadingScreen.DisableLoadScreen();
    }

    public void ExitState()
    {
        raceManager.CleanUp();
    }

    public void ProcessUpdate()
    {

    }
}
