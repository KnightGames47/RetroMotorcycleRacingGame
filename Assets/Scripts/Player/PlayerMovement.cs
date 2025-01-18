using System.Net.Mime;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour, MotorCycle_Input.IPlayerActions
{
    [Header("Movement Settings")]
    [SerializeField] public float acceleration = 500f;
    [SerializeField] public float breakingForce = 300f;
    [SerializeField] public float maxTurningAngle = 30f;

    [SerializeField] WheelCollider frontWheel;
    [SerializeField] WheelCollider backWheel;
    [SerializeField] Transform steeringModels;

    //movement variables
    private float curAcceleration = 0f;
    private float curBreakForce = 0f;
    private float curTurningAngle = 0f;

    //General references
    private MotorCycle_Input motorCycleInput;
    //private Rigidbody rb;

    #region Unity Callbacks-------------------------------------------------------------------------
    public void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if (motorCycleInput == null)
        {
            motorCycleInput = new MotorCycle_Input();
            motorCycleInput.Player.SetCallbacks(this);//We are hooking up the callbacks from the input to the ones here.
        }

        motorCycleInput.Player.Enable();
    }

    private void OnDisable()
    {
        motorCycleInput.Player.Disable();
    }

    private void FixedUpdate()
    {
        ProcessMovement();
    }


    void Update()
    {
        
    }
    #endregion

    #region Helper Functions------------------------------------------------------------------------
    private void ProcessMovement()
    {
        //apply acceleration to back wheel
        backWheel.motorTorque = curAcceleration;

        //apply breakforce if there is any to all wheels
        frontWheel.brakeTorque = curBreakForce;
        backWheel.brakeTorque = curBreakForce;

        //steering
        frontWheel.steerAngle = curTurningAngle;

        UpdateSteeringModels(frontWheel, steeringModels);
    }

    private void UpdateSteeringModels(WheelCollider col, Transform steerModel)
    {
        Vector3 pos;
        Quaternion rot;
        col.GetWorldPose(out pos, out rot);

        //steerModel.position = pos;
        //steerModel.rotation = rot;
    }

    #endregion

    #region Input Callbacks-------------------------------------------------------------------------
    public void OnAccelerate(InputAction.CallbackContext context)
    {
        if(context.performed)
            curAcceleration = acceleration;
        else curAcceleration = 0f;
    }

    public void OnBrake(InputAction.CallbackContext context)
    {
        if (context.performed)
            curBreakForce = breakingForce;
        else curBreakForce = 0f;
    }

    public void OnTurning(InputAction.CallbackContext context)
    {
        curTurningAngle = maxTurningAngle * context.ReadValue<float>();
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if(GameStateManager.Instance.currentState.StateType == GameStates.RACING)
            GameStateManager.Instance.TransitionToState(new PauseMenu_GameState(GameStateManager.Instance.currentState as Racing_GameState));
    }

    //TODO: Need to make a reverse part, that is very slow, and makes sure that you don't have any acceleration or forward momentum...

    /// <summary>
    /// DEPRECIATED DO NOT USE
    /// </summary>
    /// <param name="context"></param>
    public void OnMovement(InputAction.CallbackContext context)
    {
        
    }

    
    #endregion
}
