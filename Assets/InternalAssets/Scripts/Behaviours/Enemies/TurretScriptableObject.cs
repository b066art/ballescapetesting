using UnityEngine;

[CreateAssetMenu(fileName = "New Turret", menuName = "Enemies/Turret")]
public class TurretScriptableObject : ScriptableObject
{
    [Header("Aim")]
    public int detectionRadius;
    public float rotationSpeed;

    [Header("Attack")]
    public float cooldownTime;
    public int damage;
}
