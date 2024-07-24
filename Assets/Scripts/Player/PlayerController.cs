using Bullet;
using UniRx;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public float speed = 5f;
        public Transform firePoint;
        public float fireRate = 1f;
        public float fireRange = 10f;
        private float nextFireTime = 0f;
        private ObjectPool bulletPool;
        public IntReactiveProperty health { get; private set; }

        private Vector3 screenBounds;
        private Transform targetObject;
        private float playerWidth;
        private float playerHeight;
    
        public void Init(float speed, float fireRate, float fireRange, int health, Transform target)
        {
            this.speed = speed;
            this.fireRange = fireRange;
            this.fireRate = fireRate;
            this.health = new IntReactiveProperty();
            this.health.Value = health;
            targetObject = target;
        }

        public void TakeDamage()
        {
            health.Value--;
        }
    
        private void Start()
        {
            bulletPool = this.GetComponent<ObjectPool>();
        
            screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            playerWidth = spriteRenderer.bounds.size.x / 2;
            playerHeight = spriteRenderer.bounds.size.y / 2;
        }

        void Update()
        {
            Move();
            if (Time.time >= nextFireTime)
            {
                Shoot();
                nextFireTime = Time.time + 1f / fireRate;
            }
        }

        void Move()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);
            transform.position += movement * (speed * Time.deltaTime);
        
            Vector3 clampedPosition = transform.position;
            clampedPosition.y = Mathf.Clamp(clampedPosition.y, -screenBounds.y + playerHeight, targetObject.transform.position.y - playerHeight);
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, -screenBounds.x + playerWidth, screenBounds.x - playerWidth);
            transform.position = clampedPosition;
        }

        void Shoot()
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(firePoint.position, fireRange);
            foreach (Collider2D enemy in hitEnemies)
            {
                if (enemy.CompareTag("Enemy"))
                {
                    GameObject bullet = bulletPool.GetObject();
                    bullet.transform.position = firePoint.position;
                    bullet.transform.rotation = firePoint.rotation;
                    //bullet.GetComponent<Bullet.Bullet>().target = hitEnemies[0].transform;
                    break;
                }
            }
        }
    
        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(firePoint.position, fireRange);
        }
    }
}