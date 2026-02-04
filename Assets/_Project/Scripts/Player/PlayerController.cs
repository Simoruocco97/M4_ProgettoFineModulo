using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Camera cam;

    [Header("Movement Attributes")]
    [SerializeField] private float speed = 2f;
    [SerializeField] private float multipliedSpeed = 2f;
    private Vector3 verticalCam;
    private Vector3 horizontalCam;
    private Vector3 move;
    private float initialSpeed;
    private float horizontal;
    private float vertical;
    private bool isSlowed = false;
    private float slowMultiplier = 1f;

    [Header("Rotation Attributes")]
    [SerializeField] private float rotationSmoothness = 10f;
    private Quaternion rotTarget;

    [Header("Jump Attributes")]
    [SerializeField] private GroundCheck groundCheck;
    [SerializeField] private float jumpHeight = 2f;

    private MovingPlatforms currentPlatform;

    private void Awake()
    {
        if (rb == null) rb = GetComponent<Rigidbody>();
        if (groundCheck == null) groundCheck = GetComponent<GroundCheck>();
        if (cam == null) cam = Camera.main;

        initialSpeed = speed;
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        verticalCam = cam.transform.forward;
        verticalCam.y = 0f;
        horizontalCam = cam.transform.right;
        horizontalCam.y = 0f;

        move = (verticalCam * vertical + horizontalCam * horizontal).normalized;

        SprintCheck();

        if (Input.GetButtonDown("Jump"))
            PerformJump();
    }

    private void FixedUpdate()
    {
        Vector3 platformShift = Vector3.zero;
        if (currentPlatform != null && groundCheck.CheckIsGrounded())
        {
            Debug.Log("Bravo, hai passato il check!");
            Debug.Log(platformShift);
            platformShift = currentPlatform.GetPlatformShift();
        }

        rb.MovePosition(rb.position + move * (speed * Time.deltaTime) + platformShift);

        if (move != Vector3.zero)
        {
            rotTarget = Quaternion.LookRotation(move);    //calcola il target della rotazione
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, rotTarget, rotationSmoothness * Time.fixedDeltaTime));
        }
    }

    private void SprintCheck()
    {
        float currentSpeed = initialSpeed;

        if (Input.GetButton("Fire3")) 
            currentSpeed *= multipliedSpeed;

        if (isSlowed)
            currentSpeed *= slowMultiplier;

        speed = currentSpeed;
    }

    private void PerformJump()
    {
        if (groundCheck.CheckIsGrounded())
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
    }

    public void EnterPlatform(MovingPlatforms platform)
    {
        currentPlatform = platform;
    }

    public void ExitPlatform(MovingPlatforms platform)
    {
        if (currentPlatform == platform)
            currentPlatform = null;
    }

    public float GetSpeed() => speed;

    public float GetInitialSpeed() => initialSpeed;

    public void SpeedModify(float speed)
    {

        this.speed = speed;
    }

    public void ApplySlow(float modifier, float duration = 10f)
    {
        if (!isSlowed)
        {
            isSlowed = true;
            slowMultiplier = modifier;
            Invoke(nameof(RemoveSlow), duration);
        }
    }

    private void RemoveSlow()
    {
        isSlowed = false;
        slowMultiplier = 1f;
    }
}