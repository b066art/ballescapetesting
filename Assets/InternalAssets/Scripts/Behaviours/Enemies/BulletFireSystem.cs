using System.Collections;
using UnityEngine;

public class BulletFireSystem : MonoBehaviour
{
    [SerializeField] private float bulletForce;

    [SerializeField] private TurretScriptableObject stats;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;

    private bool canFire = true;

    public void Attack()
    {
        if (bulletPrefab != null && firePoint != null && canFire)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            bullet.GetComponent<Bullet>().damageAmount = stats.damage;

            Rigidbody rb = bullet.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddForce(firePoint.right * bulletForce, ForceMode.VelocityChange);
                StartCoroutine("CooldownTimer");
            }
        }
    }

    private IEnumerator CooldownTimer()
    {
        if (canFire)
        {
            canFire = false;
            yield return new WaitForSeconds(stats.cooldownTime);
            canFire = true;
        }
        yield return null;
    }
}
