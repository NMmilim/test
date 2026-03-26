using UnityEngine;
using System.Collections;

public class BombShooter : MonoBehaviour
{
    public GameObject bombPrefab;
    public Transform spawnPoint;

    public int maxAmmo = 5;
    public int currentAmmo;

    public float cooldown = 0.5f;
    private bool canShoot = true;

    void Start()
    {
        currentAmmo = maxAmmo;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canShoot && currentAmmo > 0)
        {
            Shoot();
            StartCoroutine(Cooldown());
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    void Shoot()
    {
        GameObject bomb = Instantiate(bombPrefab, spawnPoint.position, Quaternion.identity);

        // ยิงไปทิศที่หันล่าสุด
        Vector3 dir = transform.forward;

        bomb.GetComponent<Rigidbody>().AddForce(dir * 10f, ForceMode.Impulse);

        currentAmmo--;
    }

    IEnumerator Cooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(cooldown);
        canShoot = true;
    }

    void Reload()
    {
        currentAmmo = maxAmmo;
    }
}