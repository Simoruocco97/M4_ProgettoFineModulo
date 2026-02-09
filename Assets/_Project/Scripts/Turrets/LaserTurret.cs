using UnityEngine;

public class LaserTurret : BaseTurret
{
    [Header("Laser Infos")]
    [SerializeField] private Transform firepoint;
    [SerializeField] private float shootDistance = 50f;
    [SerializeField] private int shootDamage = 20;
    [SerializeField] private float loadTime = 4f;

    [Header("Visuals")]
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Color safeColor = Color.green;
    [SerializeField] private Color warningColor = Color.red;

    private float currentLoadTime = 0f;
    private LifeController playerLife;
    Vector3 dir;
    Vector3 endPoint;

    protected override void Awake()
    {
        base.Awake();

        if (lineRenderer == null)
            lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (!playerInRange)
        {
            currentLoadTime = 0f;
            lineRenderer.enabled = false;
            return;
        }

        if (player != null)
            dir = (player.position - firepoint.position).normalized;

        RotateTowardsPlayer();

        RaycastHit hit;
        bool hasHit = Physics.Raycast(firepoint.position, dir, out hit, shootDistance, ~0, QueryTriggerInteraction.Ignore);

        if (hit.collider != null)
            endPoint = hit.point;
        else
            endPoint = firepoint.position + dir * shootDistance;

        HandleShooting(hit);

        UpdateLaserVisual();
    }

    private void HandleShooting(RaycastHit hit)
    {
        currentLoadTime += Time.deltaTime;

        if (currentLoadTime >= loadTime)
        {
            if (hit.collider != null && hit.collider.CompareTag("Player"))
            {
                playerLife = hit.collider.GetComponent<LifeController>();
                if (playerLife != null)
                    playerLife.TakeDamage(shootDamage);
            }
            currentLoadTime = 0f;
        }
    }

    private void UpdateLaserVisual()
    {
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, firepoint.position);
        lineRenderer.SetPosition(1, endPoint);

        Color color = safeColor;
        if (currentLoadTime > loadTime * 0.5f) color = warningColor;

        lineRenderer.startColor = color;
        lineRenderer.endColor = color;
    }
}