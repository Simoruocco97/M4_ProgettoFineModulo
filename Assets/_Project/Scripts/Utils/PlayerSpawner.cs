using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform spawnPoint;

    private void Awake()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").transform;

        if (spawnPoint == null)
            Debug.LogWarning("SpawnPoint non assegnato!");
    }

    private void Start()
    {
        PlayerToSpawn();
    }

    private void PlayerToSpawn()
    {
        if (spawnPoint != null && player != null)
        {
            player.position = spawnPoint.position;
            player.rotation = spawnPoint.rotation;
        }
    }
}