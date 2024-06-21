using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] UnityEvent onHurt;
    [SerializeField] UnityEvent onDead;

    private int currentHealth;

    private bool isDead = false;

    public int MaxHealth
    {
        get { return maxHealth; }
    }

    public int CurrentHealth
    {
        get { return currentHealth; }
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }


    public void TakeDamage(int amount)
    {
        if(currentHealth >= 0)
        {
            currentHealth -= amount;
            
            if (currentHealth < 0)
            {
                currentHealth = 0;
            }
            onHurt.Invoke();
        }

        if (currentHealth <= 0)
        {
            if (!isDead)
            {
                isDead = true;
                onDead.Invoke();
            }
        }
    }
}
