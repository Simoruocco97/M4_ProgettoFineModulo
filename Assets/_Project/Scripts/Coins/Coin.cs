using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private int coinValue = 1;
    [SerializeField] private AudioManager audioManager;

    private void Awake()
    {
        if (audioManager == null)
            audioManager = FindAnyObjectByType<AudioManager>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        if (playerInventory == null)
            playerInventory = collision.GetComponent<PlayerInventory>();

        if (playerInventory == null)
            return;

        playerInventory.AddCoin(coinValue);
        audioManager.PlayCoinPickup();
        Destroy(gameObject);
    }
}