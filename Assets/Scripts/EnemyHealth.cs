using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 100;
    int currentHealth;

    [Header("Health Bar")]
    public Image healthFill;

    void Start()
    {
        currentHealth = maxHealth + GameManager.Instance.bonusHealth;
        maxHealth = currentHealth;


        if (healthFill != null)
            healthFill.fillAmount = 1f;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        Debug.Log(name + " took " + amount + " damage! Health = " + currentHealth);

        if (healthFill != null)
            healthFill.fillAmount = (float)currentHealth / maxHealth;

        if (currentHealth <= 0)
            Die();
    }

    void Die()
    {
        int coinsGained = Random.Range(1, 4); // 1 to 3 coins
        CoinManager.Instance.AddCoins(coinsGained);

        Debug.Log(gameObject.name + " died. Player earned " + coinsGained + " coins!");

        Destroy(gameObject);
    }
}
