using UnityEngine;

public class TurretTrigger : MonoBehaviour
{
    [SerializeField] private BaseTurret turret;

    private void Awake()
    {
        if (turret == null)
            turret = GetComponentInChildren<ShootingTurret>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            turret.SetPlayerInRange(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            turret.SetPlayerInRange(false);
    }
}