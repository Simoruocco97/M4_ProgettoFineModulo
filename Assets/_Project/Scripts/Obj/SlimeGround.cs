using UnityEngine;

public class SlimeGround : MonoBehaviour
{
    [SerializeField] private float speedModificator = 0.5f;
    [SerializeField] private float slimeLifetime = 10f;
    [SerializeField] private float slowTime = 3f;

    private void Start()
    {
        Destroy(gameObject, slimeLifetime);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.ApplySlow(speedModificator, slowTime);
            }
        }
    }
}