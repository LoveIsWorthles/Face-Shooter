using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 3f;
    public int damage = 10; // Add damage value

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // Vector3.right works because we rotated the firePoint in the AutoShooting script
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
/*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // Check if the enemy has a health component
            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
            if(enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }*/
}