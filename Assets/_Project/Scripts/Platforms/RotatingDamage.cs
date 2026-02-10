using UnityEngine;

public class RotatingDamage : MonoBehaviour
{
    [SerializeField] private float force = 2f;
    [SerializeField] private int damage = 30;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player trovato");

            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();
            if (playerRb != null)
            {
                Vector3 direction = (collision.transform.position - transform.position).normalized;
                playerRb.AddForce(direction * force, ForceMode.Impulse);
                Debug.Log("Player spinto");
            }

            LifeController playerLife = collision.gameObject.GetComponent<LifeController>();
            if (playerLife != null)
            {
                playerLife.TakeDamage(damage);
                Debug.Log("Player danneggiato");
            }
        }
    }
}