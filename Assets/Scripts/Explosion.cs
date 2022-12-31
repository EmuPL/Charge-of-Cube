using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float CubeSize = 0.2f;
    public int CubesInRow = 5;
    public float ExplosionForce = 50f;
    public float ExplosionRadius = 5f;
    public float ExplosionUpward = 0.3f;
    public Rigidbody PlayerRigidbody = null;

    private float CubesPivotDistance = 0f;
    private Vector3 CubesPivot = new Vector3(0f, 0f, 0f);


    private void Start()
    {
        CubesPivotDistance = CubeSize * CubesInRow / 2;
        CubesPivot = new Vector3(CubesPivotDistance, CubesPivotDistance, CubesPivotDistance);
    }

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.CompareTag("Obstacle"))
        {
            Explode();
        }
    }

    public void Explode()
    {
        gameObject.SetActive(false);

        for (int x = 0; x < CubesInRow; x++)
        {
            for (int y = 0; y < CubesInRow; y++)
            {
                for (int z = 0; z < CubesInRow; z++)
                {
                    createPiece(x, y, z);
                }
            }
        }

        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, ExplosionRadius);

        foreach (Collider hit in colliders)
        {
            Rigidbody PlayerRigidbody = hit.GetComponent<Rigidbody>();

            if (PlayerRigidbody != null)
            {
                PlayerRigidbody.AddExplosionForce(ExplosionForce, transform.position, ExplosionRadius, ExplosionUpward);
            }
        }
    }

    private void createPiece(int x, int y, int z)
    {
        GameObject piece = GameObject.CreatePrimitive(PrimitiveType.Cube);
        piece.transform.position = transform.position + new Vector3(CubeSize * x, CubeSize * y, CubeSize * z) - CubesPivot;
        piece.transform.localScale = new Vector3(CubeSize, CubeSize, CubeSize);

        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = CubeSize;
        piece.GetComponent<MeshRenderer>().material.color = Color.green;
        piece.GetComponent<Rigidbody>().AddForce(Vector3.forward * 1f, ForceMode.Impulse);
    }
}