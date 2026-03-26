using UnityEngine;
using UnityEngine.SceneManagement;

public class Bomb : MonoBehaviour
{
    public float delay = 2f;
    public float radius = 5f;
    public float force = 500f;

    void Start()
    {
        Invoke("Explode", delay);
    }

    void Explode()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider hit in hits)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
            {
                // Newton Law: F = ma (เรากำหนด force ไปเลย)
                rb.AddExplosionForce(force, transform.position, radius);
            }

            // destroy object
            if (hit.CompareTag("Destructible"))
            {
                Destroy(hit.gameObject);
                //FindObjectOfType<ScoreManager>().AddScore(10);
            }
        }

        Destroy(gameObject);
    }
}