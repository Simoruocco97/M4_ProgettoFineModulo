using System.Collections;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    [SerializeField] private PlayerInventory playerInv;
    [SerializeField] private int reqCoin = 10;
    [SerializeField] private float coinUpdateCheck = 5f;
    private int coinCounter;

    private void Awake()
    {
        if (playerInv == null) playerInv = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
    }

    private void Start()
    {
        StartCoroutine(CoinCheckCoroutine());
    }

    private IEnumerator CoinCheckCoroutine()
    {
        while (!CanDestroyDoor())
        {
            coinCounter = playerInv.GetCoin();
            yield return new WaitForSeconds(coinUpdateCheck);
        }

        DestroyDoor();
    }

    private bool CanDestroyDoor()
    {
        return coinCounter >= reqCoin;
    }

    private void DestroyDoor()
    {
        gameObject.SetActive(false);
    }
}