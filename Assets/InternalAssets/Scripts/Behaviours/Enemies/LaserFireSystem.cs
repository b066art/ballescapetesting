using System.Collections;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LaserFireSystem : MonoBehaviour
{
    [SerializeField] private float lineStartWidth, lineEndWidth;
    [SerializeField] private TurretScriptableObject stats;
    [SerializeField] private Transform firePoint;
    
    LineRenderer laserLine;

    private bool canFire = true;
    private bool laserOn = false;

    private void Awake()
    {
        laserLine = GetComponent<LineRenderer>();

        laserLine.startWidth = lineStartWidth;
        laserLine.endWidth = lineEndWidth;

        laserLine.material = new Material(Shader.Find("Sprites/Default"));

        laserLine.startColor = Color.red;
        laserLine.endColor = Color.red;
    }

    private void Update()
    {
        if (laserOn)
        {
            DrawLine();
        }
    }

    public void Attack()
    {
        StartCoroutine("ShootLaser");
    }

    private void StopAttack()
    {
        laserOn = false;
        laserLine.SetPosition(0, firePoint.position);
        laserLine.SetPosition(1, firePoint.position);
    }

    private IEnumerator ShootLaser()
    {
        if (!laserOn && canFire)
        {
            laserOn = true;
            yield return new WaitForSeconds(stats.cooldownTime);
            StopAttack();
            canFire = false;
            yield return new WaitForSeconds(stats.cooldownTime);
            canFire = true;
        }
        yield return null;
    }

    private void DrawLine()
    {
        laserLine.SetPosition(0, firePoint.position);
        
        RaycastHit hit;
        if (Physics.Raycast(firePoint.position, firePoint.right, out hit, Mathf.Infinity))
        {
            laserLine.SetPosition(1, hit.point);

            if (hit.collider.CompareTag("Player"))
        {
            PlayerHealth playerHealth = hit.collider.gameObject.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(stats.damage);
            }
        }

        }
    }
}