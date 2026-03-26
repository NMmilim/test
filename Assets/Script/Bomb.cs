using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float delay = 2f;
    public float radius = 5f;
    public float force = 100f;
    public GameObject explosionFX;

    private ScoreManager scoreManager;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();

        Invoke(nameof(Explode), delay);
    }

    void Explode()
    {
        if (explosionFX != null)
        {
            GameObject fx = Instantiate(explosionFX, transform.position, Quaternion.identity);
            Destroy(fx, 2f);
        }

        Collider[] hits = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Destructible"))
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb == null)
                {
                    rb = hit.gameObject.AddComponent<Rigidbody>();
                }

                rb.isKinematic = false;

                // ปรับค่าฟิสิกส์ให้กระเด็นแรงขึ้น
                rb.linearDamping = 0.5f;


                rb.AddExplosionForce(force, transform.position, radius, 2f, ForceMode.Impulse);

                // delay destroy เพื่อให้เห็นฟิสิกส์
                Destroy(hit.gameObject, 10f);

                if (scoreManager != null)
                {
                    scoreManager.AddScore(10);
                }
            }
        }

        Destroy(gameObject);
    }
}