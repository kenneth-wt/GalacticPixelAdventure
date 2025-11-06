using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private Vector2 position;

    public GameObject enemy;

    private float baseSpawnRate = 2.0f;
    private float minSpawnRate = 0.3f;
    private float spawnTimer;

    void Update()
    {
        float difficulty = GameManager.Instance.difficultyMultiplier;
        float spawnRate = Mathf.Max(minSpawnRate, baseSpawnRate / difficulty);

        if (Time.time > spawnTimer)
        {
            SpawnEnemy();
            spawnTimer = Time.time + spawnRate;
        }
    }

    private void SpawnEnemy()
    {
        position = transform.position;

        Vector2 randomPosition = new Vector2(position.x, Random.Range(-4.5f, 3.6f));

        Instantiate(enemy, randomPosition, transform.rotation);
    }
}
