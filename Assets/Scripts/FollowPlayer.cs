using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform Player;
    public Vector3 Offset;
    
    private void Update()
    {
        transform.position = Player.position + Offset;
    }
}
