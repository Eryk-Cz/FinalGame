using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    public string shopSceneName = "ShopScene";
    private bool battleEnded = false;

    void Update()
    {
        if (battleEnded) return;

        Team[] teams = FindObjectsOfType<Team>();

        bool teamAAlive = false;
        bool teamBAlive = false;

        foreach (Team t in teams)
        {
            if (t.team == Team.TeamType.TeamA)
                teamAAlive = true;

            if (t.team == Team.TeamType.TeamB)
                teamBAlive = true;
        }

        if (!teamAAlive || !teamBAlive)
        {
            EndBattle();
        }
    }

    void EndBattle()
    {
        battleEnded = true;
        Invoke(nameof(LoadShop), 2f); // short delay
    }

    void LoadShop()
    {
        SceneManager.LoadScene(shopSceneName);
    }
}
