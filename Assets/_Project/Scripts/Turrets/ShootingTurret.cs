using UnityEngine;

public class ShootingTurret : MonoBehaviour
{
    [Header("Shooting Infos")]
    [SerializeField] private GameObject firepoint;
    [SerializeField] private float fireRate = 1.5f;
    [SerializeField] private int force = 20;
    private float lastShoot = 0f;
    private bool playerInRange = false;

    [Header("Bullet Infos")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private int bulletLifeTime = 10;

    [Header("Turret Infos")]
    [SerializeField] private GameObject player;
    [SerializeField] private float rotationSmoothness = 5f;

    private void Update()
    {
        if (playerInRange)
        {
            if (CanShoot())
            {
                Shoot();
            }
        }

        if (player != null && playerInRange)
        {
            Quaternion rotationTarget = Quaternion.LookRotation(player.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotationTarget, rotationSmoothness * Time.deltaTime);
        }
    }

    private bool CanShoot()
    {
        return Time.time - lastShoot >= fireRate || lastShoot == 0f;
    }

    private void Shoot()
    {
        GameObject bulletPref = Instantiate(bullet, firepoint.transform.position, firepoint.transform.rotation);

        Rigidbody bulletRb = bulletPref.GetComponent<Rigidbody>();
        if (bulletRb != null)
            bulletRb.AddForce(firepoint.transform.forward * force, ForceMode.Impulse);

        lastShoot = Time.time;
        Destroy(bulletPref, bulletLifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        playerInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        playerInRange = false;
    }
}
