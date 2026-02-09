using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private UnityEvent<int> coins;
    private int coinCounter = 0;

    public void AddCoin(int coin)
    {
        coinCounter += coin;
        Debug.Log($"Moneta raccolta! Monete totali: {coinCounter}");
        coins.Invoke(coinCounter);
    }

    public int GetCoin()
    {
        return coinCounter;
    }
}