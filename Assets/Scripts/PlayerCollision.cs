using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement Movement = null;
    public GameManager GameManager = null;

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.CompareTag("Obstacle"))
        {
            Movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
