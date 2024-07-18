using UnityEngine;


public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 1;
    private ObjectPool objectPool;

    void Start()
    {
        objectPool = FindObjectOfType<ObjectPool>();
    }

    void Update()
    {
        transform.Translate(Vector2.up * (speed * Time.deltaTime));

        if (transform.position.y > 6f)
        {
            objectPool.ReturnObject(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Enemy"))
        {
            hitInfo.GetComponent<EnemyController>().TakeDamage(damage);
            objectPool.ReturnObject(gameObject);
        }
    }
}
