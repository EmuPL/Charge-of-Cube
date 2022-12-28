using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody PlayerRigidbody = null;
    private const float UnderPlatform = -1f;
    public float ForwardForce = 2000f;
    public float SidewaysForce = 500f;
    private void FixedUpdate()
    {
        PlayerRigidbody.AddForce(0, 0, ForwardForce * Time.deltaTime);
        
        if(Input.GetKey("d"))
        {
            PlayerRigidbody.AddForce(SidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if(Input.GetKey("a"))
        {
            PlayerRigidbody.AddForce(-SidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if(PlayerRigidbody.position.y < UnderPlatform)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
