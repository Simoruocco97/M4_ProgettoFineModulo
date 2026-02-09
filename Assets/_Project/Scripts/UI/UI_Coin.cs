using TMPro;
using UnityEngine;

public class UI_Coin : MonoBehaviour
{
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private TextMeshProUGUI coins;

    private void Awake()
    {
        if (playerInventory == null)
            playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();

        if (coins == null)
            coins = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void UpdateCoins()
    {
        int currentCoins = playerInventory.GetCoin();
        coins.text = currentCoins.ToString();
    }
}