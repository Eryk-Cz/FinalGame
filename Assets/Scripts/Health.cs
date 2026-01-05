using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    [Header("Health Bar")]
    public Image healthFill;

    void Start()
    {
        currentHealth = maxHealth;

        if (healthFill != null)
            healthFill.fillAmount = 1f;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        Debug.Log(gameObject.name + " took " + amount +
                  " damage! Health = " + currentHealth);

        // UPDATE HEALTH BAR
        if (healthFill != null)
            healthFill.fillAmount = (float)currentHealth / maxHealth;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
   
        Destroy(gameObject);
    }

}
