using UnityEngine;
using System.Collections;

public class EnemyAttack: MonoBehaviour
{
	[SerializeField] private EnemyStats stats;
    private float lastAttackTime = -Mathf.Infinity;
	public bool CanAttack => Time.time >= lastAttackTime + stats.attackCooldown;

	public void TryAttack(IDamageable target)
	{
		if (!CanAttack) return;
		lastAttackTime = Time.time;
		target.TakeDamage(stats.attackDamage);
    }
}
