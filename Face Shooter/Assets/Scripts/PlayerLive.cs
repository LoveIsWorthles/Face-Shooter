using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    public int lives = 3;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            lives--;

            Debug.Log("Lives left: " + lives);

            if (lives <= 0)
            {
                Debug.Log("Game Over");
                Destroy(gameObject); // remove player
            }
        }
    }
}