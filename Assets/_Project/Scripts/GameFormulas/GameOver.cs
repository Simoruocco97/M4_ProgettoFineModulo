using UnityEngine;
using UnityEngine.Events;

public class GameOver : MonoBehaviour
{
    [Header("Player Infos")]
    [SerializeField] private GameObject player;
    [SerializeField] private LifeController playerLifeController;

    [Header("GameOver Infos")]
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private int mapMaxRange = 20;
    private bool isGameOver = false;

    [Header("UnityEvent")]
    [SerializeField] private UnityEvent onGameOver;

    private void Awake()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");

        if (player != null && playerLifeController == null)
            playerLifeController = player.GetComponent<LifeController>();

        if (audioManager == null)
            audioManager = FindAnyObjectByType<AudioManager>();
    }

    private void Update()
    {
        if (!isGameOver)
            FallCheck();
    }

    private void FallCheck()
    {
        if (player == null || isGameOver) return;

        if (player.transform.position.y <= -mapMaxRange)
        {
            isGameOver = true;
            onGameOver.Invoke();
            audioManager.StopBackgroundMusic();
            audioManager.PlayGameOverSound();
            playerLifeController.DestroyIfDead();
        }
    }
}