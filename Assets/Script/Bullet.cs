using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Vector2 direction = new Vector2(1, 0);
    public float speed = 2;

    public float lifeTime = 3;

    public float damage = 100f;

    Vector2 position;

    public Vector2 velocity;

    public bool isEnemy = false;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);

    }

    // Update is called once per frame
    void Update()
    {
        velocity = direction * speed;
    }

    private void FixedUpdate()
    {
        position = transform.position;

        position += velocity * Time.fixedDeltaTime;

        transform.position = position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            other.GetComponent<Enemy>().takeDamage(damage);
            Destroy(this.gameObject);
        }

    }
}
