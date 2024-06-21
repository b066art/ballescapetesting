using UnityEngine;

public class Bullet : MonoBehaviour
{   
    public int damageAmount;

    private Collider col;

    private void Start()
    {
        col = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                col.enabled = false;
                playerHealth.TakeDamage(damageAmount);
            }
        }

        Destroy(gameObject);
    }
}
