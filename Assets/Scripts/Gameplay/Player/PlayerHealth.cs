using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour, IDamageable
{
	[SerializeField] private int maxHealth = 100;
	private int currentHealth;

	private void Awake()
	{
		currentHealth = maxHealth;
	}
	public void TakeDamage(int amount)
	{
		currentHealth -= amount;

		if (currentHealth <= 0)
		{
			currentHealth = 0;
			Die();
		}

	}
	private void Die()
	{
		Destroy(gameObject);
	}
}
