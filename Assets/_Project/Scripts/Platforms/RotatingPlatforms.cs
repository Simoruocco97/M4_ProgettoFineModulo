using UnityEngine;

public class RotatingPlatforms : MonoBehaviour
{
    [SerializeField] private Transform rotationCenter;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed = 5f;

    private void Awake()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
            rb.isKinematic = true;
        }
    }

    private void Update()
    {
        transform.RotateAround(rotationCenter.position, Vector3.down, speed * Time.deltaTime);
    }
}