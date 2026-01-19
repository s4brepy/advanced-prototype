using UnityEngine;

public class EnemyHealth : MonoBehaviour,IDamageable
{
    [SerializeField] private EnemyStats stats;
    
    private int currentHealth;
    private EnemyMovement movement;
    private EnemySpawner spawner;
    private void Awake()
    {
        currentHealth = stats.maxHealth;
        movement = GetComponent<EnemyMovement>();
    }
    public void Start()
    {
        spawner = Object.FindAnyObjectByType<EnemySpawner>();
    }
    public void TakeDamage(int amount)
    {
        if (movement != null) 
        {
        Vector2 knockbackDir = transform.position - GameObject.FindWithTag("Player").transform.position;
            movement.ApplyKnockback(knockbackDir);
        }
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        if (spawner != null)
        {
            spawner.OnEnemyDestroyed();
        }
        Destroy(gameObject);
    }
}
