using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameStates
{
    CREDITS,
    CUSTOMIZATION,
    LEVEL_SELECT,
    MAIN_MENU,
    PAUSE,
    POST_RACE,
    RACING,
    SETTINGS
}

public class GameStateManager : MonoBehaviour
{
    public IGameState currentState {  get; private set; }

    public static GameStateManager Instance { get; private set; }

    public LoadingScreen_Presenter loadingScreen;

    public PauseMenu_GameState pauseState { get; private set; }

    private void Awake()
    {
        //This is going to be the singleton that controls the states of the game. 
        //This will always be present when the game is started.
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        loadingScreen = new LoadingScreen_Presenter();
        loadingScreen.Init();
        Instance = this;
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        TransitionToState(new MainMenu_GameState());//For Production
        //TransitionToState(new Racing_GameState("Track_01_Scene"));//For Testing
    }

    private void Update()
    {
        currentState?.ProcessUpdate();
    }

    private void OnApplicationQuit()
    {
        //We want to release all of the set up here...
        Application.Quit();
    }

    /// <summary>
    /// This is the main driver of changing states. 
    /// This will take care of entering and exiting states.
    /// </summary>
    /// <param name="nextState">The state that you are wishing to enter.</param>
    public void TransitionToState(IGameState nextState)
    {
        Debug.Log($"GameState transistion {currentState?.ToString() ?? "null"} => {nextState?.ToString() ?? "null"}");
        currentState?.ExitState();
        currentState = nextState;
        currentState?.EnterState();
    }

    public void EnterPauseState()
    {
        pauseState = new PauseMenu_GameState();
        pauseState?.EnterState();
    }

    public void ExitPauseState()
    {
        pauseState?.ExitState();
        pauseState = null;
    }
}
