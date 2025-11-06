using UnityEngine;

public class Enemy : MonoBehaviour
{
    Vector2 position;

    public float movementSpeed = 1f;
    public float health = 100f;
    public float damage = 25f;
    public int enemyValue = 0;

    void Start()
    {
        movementSpeed *= GameManager.Instance.difficultyMultiplier;
    }

    void Update()
    {
        position = transform.position;

        Movement();

        transform.position = position;
    }

    void Movement()
    {
        position.x -= movementSpeed * Time.deltaTime;

        if (position.x < -12)
        {
            Score.scoreValue -= enemyValue;
            Destroy(gameObject);
        }
    }

    public void takeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            GameManager.Instance.IncreaseKillCount();
            Destroy(this.gameObject);
        }
    }
}
