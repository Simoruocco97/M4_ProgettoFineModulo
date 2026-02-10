using UnityEngine;

public class HealingCoin : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private LifeController playerLifeController;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private int healingPower = 5;

    private void Awake()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");

        if (player != null && playerLifeController == null)
            playerLifeController = player.GetComponent<LifeController>();

        if (audioManager == null)
            audioManager = FindAnyObjectByType<AudioManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (playerLifeController != null)
            {
                playerLifeController.AddHp(healingPower);
                audioManager.PlayCoinPickup();
                Destroy(gameObject);
            }
        }
    }
}