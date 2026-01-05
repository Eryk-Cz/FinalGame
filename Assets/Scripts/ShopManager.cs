using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public int unitCost = 5;
    public int upgradeCost = 5;

    public GameObject unitPrefab;
    public Transform spawnPoint;

    public void BuyUnit()
    {
        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager missing!");
            return;
        }

        if (unitPrefab == null || spawnPoint == null)
        {
            Debug.LogError("ShopManager references not set!");
            return;
        }

        if (GameManager.Instance.coins < unitCost)
        {
            Debug.Log("Not enough coins!");
            return;
        }

        GameManager.Instance.coins -= unitCost;
        Instantiate(unitPrefab, spawnPoint.position, Quaternion.identity);
    }

    public void UpgradeUnits()
    {
        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager missing!");
            return;
        }

        if (GameManager.Instance.coins < upgradeCost)
        {
            Debug.Log("Not enough coins!");
            return;
        }

        GameManager.Instance.coins -= upgradeCost;
        GameManager.Instance.bonusHealth += 5;
        GameManager.Instance.bonusDamage += 5;
    }
}
