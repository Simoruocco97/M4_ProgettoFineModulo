using UnityEngine;

public class ShootingTurret : BaseTurret
{
    [Header("Shooting Infos")]
    [SerializeField] private Transform firepoint;
    [SerializeField] private float fireRate = 1.5f;
    [SerializeField] private int force = 20;
    [SerializeField] private GameObject bullet;
    [SerializeField] private int bulletLifeTime = 10;

    private float lastShoot = 0f;

    private void Update()
    {
        if (playerInRange)
        {
            RotateTowardsPlayer();
            if (Time.time - lastShoot >= fireRate)
                Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bulletPref = Instantiate(bullet, firepoint.position, firepoint.rotation);

        Rigidbody bulletRb = bulletPref.GetComponent<Rigidbody>();
        if (bulletRb != null)
        {
            Vector3 dir = (player.position - firepoint.position).normalized;
            bulletRb.AddForce(dir * force, ForceMode.Impulse);
        }

        lastShoot = Time.time;
        Destroy(bulletPref, bulletLifeTime);
    }
}