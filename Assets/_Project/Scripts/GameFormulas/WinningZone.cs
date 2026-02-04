using UnityEngine;
using UnityEngine.Events;

public class WinningZone : MonoBehaviour
{
    [SerializeField] private UnityEvent onWinning;
    private PlayerController playerController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.SpeedModify(0f);
                onWinning.Invoke();
            }
        }
    }
}