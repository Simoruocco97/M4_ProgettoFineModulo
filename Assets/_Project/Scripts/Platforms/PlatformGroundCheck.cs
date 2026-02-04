using UnityEngine;

public class PlatformGroundCheck : MonoBehaviour
{
    [SerializeField] private MovingPlatforms platform;
    [SerializeField] private PlayerController player;

    private void Awake()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        if (platform == null)
            platform = GetComponentInParent<MovingPlatforms>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            player.EnterPlatform(platform);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            player.ExitPlatform(platform);
    }
}
