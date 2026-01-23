using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Camera cam;
    private Vector3 verticalCam;
    private Vector3 horizontalCam;


    [Header("Movement Attributes")]
    [SerializeField] private float speed = 2f;
    [SerializeField] private float multipliedSpeed = 2f;
    private Vector3 move;
    private float initialSpeed;
    private float multipledSpeed;
    private float horizontal;
    private float vertical;
    private Vector3 finalDir;

    [Header("Rotation Attributes")]
    [SerializeField] private float rotationSmoothness = 10f;
    private Quaternion rotTarget;

    [Header("Jump Attributes")]
    [SerializeField] private GroundCheck canJump;
    [SerializeField] private float jumpHeight = 2f;

    private void Awake()
    {
        if (rb == null) rb = GetComponent<Rigidbody>();
        if (canJump == null) canJump = GetComponent<GroundCheck>();
        if (cam == null) cam = Camera.main;
    }

    private void Start()
    {
        initialSpeed = speed;
        multipledSpeed = speed * multipliedSpeed;
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        verticalCam = cam.transform.forward;
        verticalCam.y = 0f;
        horizontalCam = cam.transform.right;
        horizontalCam.y = 0f;

        move = (verticalCam * vertical +  horizontalCam * horizontal).normalized;

        SprintCheck();

        if (Input.GetButtonDown("Jump"))
        {
            PerformJump();
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + move * (speed * Time.deltaTime));

        if (move != Vector3.zero)
        {
            rotTarget = Quaternion.LookRotation(move);    //calcola il target della rotazione
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, rotTarget, rotationSmoothness * Time.fixedDeltaTime));
        }
    }

    private void SprintCheck()
    {
        if (Input.GetButton("Fire3")) speed = multipledSpeed;
        if (Input.GetButtonUp("Fire3")) speed = initialSpeed;
    }

    private void PerformJump()
    {
        if (canJump.CheckIsGrounded())
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
    }
}
