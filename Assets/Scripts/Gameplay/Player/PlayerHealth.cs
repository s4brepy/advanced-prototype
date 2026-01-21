using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour, IDamageable
{

	[SerializeField] PlayerHitVisual playerHitVisual;
	public int maxHealth { get; private set; } = 100;
	private static int currentHealth;
	private GameObject gamemanagerObject;
	private GameManager gamemanager;

	private GameObject healthSystem;
	private HealthUI healthUI;


	private void Awake()
	{
		currentHealth = maxHealth;
		gamemanagerObject = GameObject.FindGameObjectWithTag("GameManager");
		gamemanager = gamemanagerObject.GetComponent<GameManager>();
		healthSystem = GameObject.FindGameObjectWithTag("HeartSystem");
		healthUI = healthSystem.GetComponent<HealthUI>();
		
	}
	public void Start()
	{
        currentHealth = maxHealth;
        healthUI.UpdateHearts(currentHealth);
    }
	public void TakeDamage(int amount)
	{
		
		currentHealth -= amount;
		Debug.Log(currentHealth);
        healthUI.UpdateHearts(currentHealth);
		playerHitVisual.OnPlayerHit();
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
