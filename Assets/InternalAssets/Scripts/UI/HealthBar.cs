using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Color inactiveColor;

    private PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
    }

    public void UpdateBar()
    {
        for (int i = 0; i < playerHealth.MaxHealth - playerHealth.CurrentHealth; i++)
        {
            transform.GetChild(i).GetComponent<Image>().color = inactiveColor;
        }
    }
}
