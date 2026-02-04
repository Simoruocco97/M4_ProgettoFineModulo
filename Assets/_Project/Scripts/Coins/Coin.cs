using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private int coinValue = 1;

    private void OnTriggerEnter(Collider collision)
    {
        if (!collision.CompareTag("Player")) 
            return;

        if (playerInventory == null) 
            playerInventory = collision.GetComponent<PlayerInventory>();

        if (playerInventory == null) 
            return;

        playerInventory.AddCoin(coinValue);
        Destroy(gameObject);
    }
}