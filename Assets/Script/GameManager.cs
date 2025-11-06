using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int killCount = 0;
    public float difficultyMultiplier = 1f;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void IncreaseKillCount()
    {
        killCount++;
        difficultyMultiplier = 1f + killCount * 0.05f;
    }
}
