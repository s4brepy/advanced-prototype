using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Enemy Stats")]
public class EnemyStats : ScriptableObject
{
    public int maxHealth = 30;
    public float moveSpeed = 2f;
    public float detectionRadius = 20f;
    public float attackRadius = 0.4f;
    public int attackDamage = 10;
    public float attackCooldown = 1f;
}
