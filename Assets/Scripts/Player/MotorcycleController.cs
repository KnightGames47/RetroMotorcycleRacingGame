using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class MotorcycleController : MonoBehaviour, MotorCycle_Input.IPlayerActions
{
    [Header("Acceleration and Braking")]
    [SerializeField] public float maxSpeed = 50;
    [SerializeField] public float acceleration = 500f;
    [SerializeField] public float nonAccelerationDrag = 50f;
    [SerializeField] public float breakingForce = 300f;

    [Header("Steering")]
    [SerializeField] public float steeringForce = 10f;
    [SerializeField] public float maxSteerVelocity = 400f;
    [SerializeField] public float steeringLimiter = 5f;
    [SerializeField] public float autoCenterMod = 3f;
    [SerializeField] public float leaningMod = 5f;
    [SerializeField] public float turningMod = 3f;
    [SerializeField] public float maxLeanAngle = 70f;

    [Header("General")]
    [SerializeField] public GameObject playerModel;
    [SerializeField] public GameObject orientation;

    //movement variables
    private float curAcceleration = 0f;
    private float curBreakForce = 0f;
    private float curSteerForce = 0f;

    //General references
    private MotorCycle_Input motorCycleInput;

    [SerializeField] Rigidbody rb;

    #region Unity Callbacks-------------------------------------------------------------------------
    public void OnEnable()
    {
        if (motorCycleInput == null)
        {
            motorCycleInput = new MotorCycle_Input();
            motorCycleInput.Player.SetCallbacks(this);//We are hooking up the callbacks from the input to the ones here.
        }

        //motorCycleInput.Player.Enable();
    }

    private void OnDisable()
    {
        motorCycleInput.Player.Disable();
    }
    
    private void FixedUpdate()
    {
        Accelerate();

        Brake();

        Steer();

        HandleLean();
    }

    #endregion

    #region Public Helpers-------------------------------------------------------------
    public void EnablePlayerControls()
    {
        motorCycleInput.Player.Enable();
    }

    public void DisablePlayerControls()
    {
        motorCycleInput.Player.Disable();
    }
    #endregion

    #region Helper Functions------------------------------------------------------------------------
    private void Accelerate()
    {
        if(curAcceleration != 0)
            rb.linearDamping = 0;
        else
            rb.linearDamping = nonAccelerationDrag;//adding drag to the feel

        if (rb.linearVelocity.z >= maxSpeed) return;

        rb.AddForce(rb.transform.forward * curAcceleration);
    }
    private void Brake()
    {
        if (rb.linearVelocity.z <= 0) return; //This doesn't allow us to go backwards... Need to fix this later

        rb.AddForce(-rb.transform.forward * curBreakForce);
    }

    private void Steer()
    {
        if (curSteerForce != 0)
        {
            float speedSteerLimiter = rb.linearVelocity.z / steeringLimiter;
            speedSteerLimiter = Mathf.Clamp01(speedSteerLimiter);

            rb.AddForce(rb.transform.right * curSteerForce * speedSteerLimiter);

            float normalizedSteer = rb.linearVelocity.x / maxSteerVelocity;

            normalizedSteer = Mathf.Clamp(normalizedSteer, -1, 1);

            rb.linearVelocity = new Vector3(normalizedSteer * maxSteerVelocity, 0, rb.linearVelocity.z);
        }
        else
        {
            rb.linearVelocity = Vector3.Lerp(rb.linearVelocity, new Vector3(0, 0, rb.linearVelocity.z), Time.fixedDeltaTime * autoCenterMod);
        }
    }

    private void HandleLean()
    {
        float leanAngle = Mathf.Clamp(rb.linearVelocity.x * -leaningMod, -maxLeanAngle, maxLeanAngle);
        float yTurnAngle = rb.linearVelocity.x * turningMod;

        playerModel.transform.rotation = Quaternion.Euler(0, yTurnAngle, leanAngle);
        orientation.transform.rotation = Quaternion.Euler(0, yTurnAngle, 0);
    }
    #endregion

    #region Input Callbacks-------------------------------------------------------------------------
    public void OnAccelerate(InputAction.CallbackContext context)
    {
        curAcceleration = acceleration * context.ReadValue<float>();
    }

    public void OnBrake(InputAction.CallbackContext context)
    {
        curBreakForce = breakingForce * context.ReadValue<float>();
    }

    public void OnTurning(InputAction.CallbackContext context)
    {
        curSteerForce = steeringForce * context.ReadValue<float>();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        
    }
    #endregion
}
