using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private Transform player;
    public float moveSpeed = 3f;  
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        // Automatically find the player by Tag (Make sure Player has "Player" tag)
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null) 
        {
            player = playerObj.transform;
        }
    }

    void Update()
    {
        if (player != null)
        {
            // Calculate direction
            Vector2 direction = (player.position - transform.position).normalized;
            movement = direction;
        }
    }

    void FixedUpdate()
    {
        if(player != null)
        {
            MoveEnemy(movement);
        }
    }

    void MoveEnemy(Vector2 direction)
    {
        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
    }
}