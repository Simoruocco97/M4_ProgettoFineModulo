using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    [Header("Platform Settings")]
    [SerializeField] private Transform[] checkpoints;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float offset = 0.01f;
    [SerializeField] private float speed = 2f;
    private Vector3 platformShift;
    private Vector3 lastPosition;

    [Header("Platform Pause Manager")]
    [SerializeField] private float pauseDuration = 1.5f;
    private float pauseTime = 0f;
    private bool isPaused = false;
    private int index;

    [Header("Player Infos")]
    [SerializeField] private PlayerController playerController;

    public Vector3 GetPlatformShift()
    {
        return platformShift;
    }

    private void Awake()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
            rb.isKinematic = true;
        }

        lastPosition = transform.position;
    }

    private void FixedUpdate()
    {
        MoveAlongCheckpoints();

        platformShift = transform.position - lastPosition;
        lastPosition = transform.position;
    }

    private void MoveAlongCheckpoints()
    {
        if (checkpoints.Length <= 0) return;

        if (isPaused)
        {
            pauseTime -= Time.fixedDeltaTime;

            if (pauseTime <= 0f)
                isPaused = false;
            else
                return;
        }

        Vector3 target = checkpoints[index].position;
        Vector3 newPos = Vector3.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);

        if (Vector3.Distance(rb.position, target) < offset)
        {
            isPaused = true;
            pauseTime = pauseDuration;

            index++;
            if (index >= checkpoints.Length)
                index = 0;
        }
    }
}