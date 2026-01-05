using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int coins = 0;
    public int bonusHealth = 0;
    public int bonusDamage = 0;

    void Awake()
    {
        Debug.Log("GameManager Awake in scene: " + gameObject.scene.name);

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
