using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player;      // Drag your Player object here in the Inspector
    public float moveSpeed = 3f;  
    private Rigidbody2D rb;
    private Vector2 direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (player != null)
        {
            // 1. Calculate the vector pointing from Enemy to Player
            Vector3 relativePos = player.position - transform.position;
            
            // 2. Convert to a unit vector (length of 1) so speed is consistent
            direction = relativePos.normalized;
        }
    }

    void FixedUpdate()
    {
        // 3. Move the Rigidbody toward the player
        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
    }
}
