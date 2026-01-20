using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour, IDamageable
{
	[SerializeField] private int maxHealth = 100;
	private int currentHealth;
	private GameObject gamemanagerObject;
	private GameManager gamemanager;

	private void Awake()
	{
		currentHealth = maxHealth;
		gamemanagerObject = GameObject.FindGameObjectWithTag("GameManager");
		gamemanager = gamemanagerObject.GetComponent<GameManager>();
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
		gamemanager.SetState(GameStates.GAMEOVER);
	}
}
