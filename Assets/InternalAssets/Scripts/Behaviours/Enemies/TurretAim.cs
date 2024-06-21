using System;
using UnityEngine;
using UnityEngine.Events;

public class TurretAim : MonoBehaviour
{
    [SerializeField] private TurretScriptableObject stats;
    [SerializeField] string targetTagFilter;
    [SerializeField] private Transform firePoint;
    [SerializeField] UnityEvent onTargetLocked;

    private SphereCollider turretCollider;

    private void Start()
    {
        turretCollider = GetComponent<SphereCollider>();
        turretCollider.radius = stats.detectionRadius;
    }

    private void OnTriggerStay(Collider other)
    {
        if(!String.IsNullOrEmpty(targetTagFilter) && !other.gameObject.CompareTag(targetTagFilter)) return;
        AimOnTarget(other.transform);
        CheckTargetVisibility(other.transform);
    }

    private void AimOnTarget(Transform target)
    {
        Vector3 directionToTarget = target.position - transform.position;
        directionToTarget.z = 0;

        float angle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * stats.rotationSpeed);
    }

    private void CheckTargetVisibility(Transform target)
    {
        Vector3 direction = target.position - firePoint.position;

        RaycastHit hit;
        
        if (Physics.Raycast(firePoint.position, direction, out hit))
        {
            if (hit.collider.CompareTag("Player"))
            {
                onTargetLocked.Invoke();
            }
        }
    }
}
