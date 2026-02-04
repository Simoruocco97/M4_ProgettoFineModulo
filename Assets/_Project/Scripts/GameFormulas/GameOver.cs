using UnityEngine;

public class GameOver : MonoBehaviour
{
    [Header("Player Infos")]
    [SerializeField] private GameObject player;
    [SerializeField] private LifeController playerLifeController;

    [Header("GameOver Infos")]
    [SerializeField] private int mapMaxRange = 20;
    private bool isGameOver = false;

    private void Awake()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");

        if (player != null && playerLifeController == null)
            playerLifeController = player.GetComponent<LifeController>();
    }

    private void Update()
    {
        if (!isGameOver)
        {
            FallCheck();
        }
    }

    private void FallCheck()
    {
        if (player == null) return;

        if (player.transform.position.y <= -mapMaxRange)
        {
            playerLifeController.TakeDamage(999);
        }
    }
}