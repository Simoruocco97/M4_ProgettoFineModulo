using UnityEngine;

public abstract class BaseTurret : MonoBehaviour
{
    [Header("Base Turret Infos")]
    [SerializeField] protected float rotationSpeed = 180f;
    [SerializeField] protected Transform player;

    protected bool playerInRange = false;

    protected virtual void Awake()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void SetPlayerInRange(bool inRange)
    {
        playerInRange = inRange;
    }

    protected void RotateTowardsPlayer()
    {
        if (player == null || !playerInRange) return;

        Vector3 dir = player.position - transform.position;
        dir.y = 0f;

        if (dir != Vector3.zero)
        {
            Quaternion rotationTarget = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationTarget, rotationSpeed * Time.deltaTime);
        }
    }
}