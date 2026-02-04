using UnityEngine;

public class RotatingPlatforms : MonoBehaviour
{
    [SerializeField] private Transform rotationCenter;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float force = 10f;

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
        transform.RotateAround(rotationCenter.position, Vector3.up, speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();
            if (playerRb != null)
            {
                Vector3 direction = (collision.transform.position - transform.position).normalized;
                playerRb.AddForce(direction * force, ForceMode.Impulse);
            }
        }
    }
}