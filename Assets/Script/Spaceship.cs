using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spaceship : MonoBehaviour
{
    Gun[] guns;

    public HealthBar healthBar;

    public int maxHealth = 100;
    public int currentHealth = 100;


    public float fireRate = 0.3f;
    private float fireTime ;

    public float movementSpeed = 10;

    private Vector2 position;

    bool speedup;

    [SerializeField] private AudioSource shootSoundEffect;


    // Start is called before the first frame update
    void Start()
    {
        guns = GetComponentsInChildren<Gun>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {

        position = transform.position;

        float moveAmount = movementSpeed * Time.deltaTime;

        Movement(moveAmount);

        transform.position = position;

        if (Input.GetKey("space") &&  Time.time> fireTime)
        {
            shootSoundEffect.Play();
            foreach (Gun gun in guns)
            {
                gun.Shoot();
            }
            fireTime = Time.time + fireRate;
        }
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }


    private void Movement(float moveAmount)
    {
        //Speed up
        if (Input.GetKey(KeyCode.LeftShift))
            moveAmount *= 1.5f;

        //up movement
        if (Input.GetKey("w"))
            position.y += moveAmount;

        //down movement
        if (Input.GetKey("s"))
            position.y -= moveAmount;

        //right movement
        if (Input.GetKey("d"))
            position.x += moveAmount;

        //left movement
        if (Input.GetKey("a"))
            position.x -= moveAmount;

        if (position.x <= -8f)
        {
            position.x = -8f;
        }
        if (position.x >= 8f)
        {
            position.x = 8f;
        }
        if (position.y <= -4.7f)
        {
            position.y = -4.7f;
        }
        if (position.y >= 3.6f)
        {
            position.y = 3.6f;
        }

    }

    void AddHealth()
    {
        currentHealth += 25;

        healthBar.SetHealth(currentHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet bullet = collision.GetComponent<Bullet>();
        if (bullet != null)
        {
            if (bullet.isEnemy)
            {
                TakeDamage(25);
            }
        }




        PowerUp powerUp = collision.GetComponent<PowerUp>();
        if (powerUp)
        {
            if (powerUp.addHealth)
            {
                AddHealth();
            }
            Destroy(powerUp.gameObject);
        }
    }

}
