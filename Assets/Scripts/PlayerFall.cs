using UnityEngine;

public class PlayerFall : MonoBehaviour
{
    private const float FALL_HEIGHT = 0f;

    public Rigidbody PlayerRigidbody = null;
    public Explosion explosion = null;

    private void FixedUpdate()
    {
        if (PlayerRigidbody.transform.position.y < FALL_HEIGHT)
        {
            FindObjectOfType<GameManager>().EndGame();
            explosion.Explode();
        }
    }
}
