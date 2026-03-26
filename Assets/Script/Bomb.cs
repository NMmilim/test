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
            if (hit.CompareTag("Destructible"))
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb == null)
                {
                    rb = hit.gameObject.AddComponent<Rigidbody>();
                }

                // 🔥 ปลดล็อกก่อน
                rb.isKinematic = false;

                // ใส่แรงระเบิด
                rb.AddExplosionForce(force, transform.position, radius, 2f);

                // หายหลัง 3 วิ
                Destroy(hit.gameObject, 3f);

                // score
                ScoreManager sm = FindObjectOfType<ScoreManager>();
                if (sm != null)
                {
                    sm.AddScore(10);
                }
            }
        }

        Destroy(gameObject);
    }
}