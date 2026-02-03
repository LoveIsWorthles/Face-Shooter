using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 3f;

    void Start()
    {
        // Destroy the bullet after a few seconds so they don't fly forever
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If it hits an enemy, destroy the bullet (and logic for damaging enemy)
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}