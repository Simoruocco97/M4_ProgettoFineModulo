using UnityEngine;

public class SlimeProjectile : MonoBehaviour
{
    [SerializeField] private GameObject slimePrefab;
    [SerializeField] private float bulletLifeTime = 10f;

    private void Start()
    {
        Destroy(gameObject, bulletLifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Terrain"))
        {
            Vector3 spawnPos = transform.position;

            if (Physics.Raycast(spawnPos + Vector3.up, Vector3.down, out RaycastHit hit, 10f, LayerMask.GetMask("Terrain")))
                spawnPos.y= hit.point.y;

            Instantiate(slimePrefab, spawnPos, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}