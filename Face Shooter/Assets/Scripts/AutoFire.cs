using UnityEngine;

public class AutoShooting : MonoBehaviour
{
    [Header("References")]
    public GameObject bulletPrefab;
    public Transform firePoint;

    [Header("Settings")]
    public float fireRate = 0.5f;       // Time between shots
    public float range = 6f;            // How far the player can see enemies
    public LayerMask enemyLayer;        // Which objects count as "Enemies"

    private float nextFireTime;
    private Transform target;

    void Update()
    {
        // 1. Continuously look for the closest enemy
        FindClosestEnemy();

        // 2. If it's time to shoot...
        if (Time.time >= nextFireTime)
        {
            // ...AND we actually found a target
            if (target != null)
            {
                Shoot();
                nextFireTime = Time.time + fireRate;
            }
            else
            {
                // Helpful log to tell you why it's NOT shooting
                // (Comment this out later if it spams your console too much)
                 Debug.Log("Weapon ready, but no enemies in range!");
            }
        }
    }

    void FindClosestEnemy()
    {
        // Get all colliders inside the "Range" circle that are on the "Enemy Layer"
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, range, enemyLayer);
        
        float shortestDistance = Mathf.Infinity;
        Transform nearestEnemy = null;

        foreach (Collider2D enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy.transform;
            }
        }

        target = nearestEnemy;
    }

    void Shoot()
    {
        // Safety Check: Did you forget to assign the prefab?
        if (bulletPrefab == null || firePoint == null)
        {
            Debug.LogError("CANNOT SHOOT: Please assign BulletPrefab and FirePoint in the Inspector!");
            return;
        }

        // Math: Rotate the FirePoint to look at the enemy
        Vector2 direction = (target.position - firePoint.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        firePoint.rotation = Quaternion.Euler(0f, 0f, angle);

        // Spawn the bullet
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        
        Debug.Log("Bang! Shot fired at: " + target.name);
    }

    // Visualize the Range in the Scene view so you can tune it
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}