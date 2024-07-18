using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 2f;
    public int health = 3;

    void Update()
    {
        transform.Translate(Vector2.down * (speed * Time.deltaTime));
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}