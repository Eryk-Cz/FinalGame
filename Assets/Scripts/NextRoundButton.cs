using UnityEngine;
using UnityEngine.SceneManagement;

public class NextRoundButton : MonoBehaviour
{
    public string battleSceneName = "2nd iteration game";

    public void LoadNextRound()
    {
        SceneManager.LoadScene(battleSceneName);
    }
}
