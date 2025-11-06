using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public GameObject explosion;
    public GameObject PowerUp;

    public int enemyValue = 0;
    int randomNumber;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet bullet = collision.GetComponent<Bullet>();

        if (bullet != null)
        {
            if (!bullet.isEnemy)
            {
                Score.scoreValue += enemyValue;
                Destroy(gameObject);
                Destroy(bullet.gameObject);
                Instantiate(explosion, transform.position, Quaternion.identity);

                randomNumber = Random.Range(0, 10);
                if (randomNumber == 1)
                {
                    Instantiate(PowerUp, transform.position, transform.rotation);
                }


            }

        }

        Spaceship player = collision.GetComponent<Spaceship>();
        if (player != null)
        {
            player.TakeDamage(25);
            Destroy(gameObject);

        }
    }

}
