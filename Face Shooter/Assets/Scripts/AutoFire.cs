using UnityEngine;

public class AutoShooting : MonoBehaviour
{
    [Header("Settings")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 0.5f; // Time in seconds between shots

    private float nextFireTime;

    void Update()
    {
        // 1. Check if the current time is greater than the scheduled 'next' shot time
        if (Time.time >= nextFireTime)
        {
            Shoot();
            
            // 2. Reset the timer by adding the fireRate delay to the current time
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}