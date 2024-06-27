using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject bulletPrefab;         
    public Transform firePoint;             
    public float shootInterval = 1f;       
    public float bulletSpeed = 10f;         
    public float detectionRange = 10f;      
    public int health = 100;               

    private Transform player;               
    private float shootTimer = 0f;          

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= detectionRange)
        {
            transform.LookAt(player);

            if (shootTimer <= 0f)
            {
                Shoot(); 
                shootTimer = shootInterval; 
            }
            else
            {
                shootTimer -= Time.deltaTime; 
            }
        }
    }

    public void TakeDamage(int amount)
    {
       
        health -= amount;
        

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        
        Destroy(gameObject);
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        if (bulletRb != null)
        {
            bulletRb.velocity = (player.position - firePoint.position).normalized * bulletSpeed;
        }
    }
}
