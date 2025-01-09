using System.Net.Mime;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour, MotorCycle_Input.IPlayerActions
{
    [Header("Movement Settings")]
    [SerializeField] public float maxSpeed;
    [SerializeField] public float acceleration;
    [SerializeField] public float deceleration;
    [SerializeField] public float turnSpeed = 5f;

    //movement variables
    private bool isAccelerating = false;
    private bool isDecelerating = false;
    private float curSpeed = 0f;
    private float turningDir = 0f;
    private Vector3 playerMoveDirection;

    //General references
    private MotorCycle_Input motorCycleInput;
    private Rigidbody rb;
    private Collider collider;
    private bool isGrounded;

    #region Unity Callbacks-------------------------------------------------------------------------
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
    }
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
        //Need to figure out acceleration/decceleration later
        Vector3 moveVector = transform.TransformDirection(playerMoveDirection) * maxSpeed;

        //UP: (0, 1, 0)
        transform.Rotate(Vector3.up * turningDir * Time.deltaTime * turnSpeed);

        rb.linearVelocity = new Vector3(moveVector.x, rb.linearVelocity.y, moveVector.z);
    }

    #endregion

    #region Input Callbacks-------------------------------------------------------------------------
    public void OnAccelerate(InputAction.CallbackContext context)
    {
        //Debug.Log("Accelerating");
    }

    public void OnBrake(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();
    }

    public void OnTurning(InputAction.CallbackContext context)
    {
        turningDir = context.ReadValue<float>();
        //Debug.Log("Tuning dir: " + turningDir);
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        //This is a temp input function, we will reconfigure this later...
        Vector3 moveDir = Vector3.zero;
        //moveDir.x = context.ReadValue<Vector2>().x;
        moveDir.z = context.ReadValue<Vector2>().y;

        playerMoveDirection = moveDir;
    }
    #endregion
}
