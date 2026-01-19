using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

public class EnemyAI : MonoBehaviour
{

    [Header("Ranges")]
    [SerializeField] private EnemyStats stats;

    private GameObject playerObj;
    private Transform player;
    private EnemyMovement movement;

    private EnemyState currentState;
    private float distance;

    private EnemyAttack attack;

    private void Awake()
    {
        movement = GetComponent<EnemyMovement>(); // Get the EnemyMovement component
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player"); 
        player = playerObj.transform; // Get the player's transform
        currentState = EnemyState.Idle; // Initialize state to Idle

        attack = GetComponent<EnemyAttack>(); // Get the EnemyAttack component
    }

    private void Update()
    {
        if (!player.IsUnityNull())
        {
            distance = Vector2.Distance(transform.position, player.position);
        }
        UpdateState(distance);

        Act(distance);
       
    }
    private void UpdateState(float distance)
    {
        if (distance <= stats.attackRadius)
        { 
            currentState = EnemyState.Attack;
        }
        else if (distance <= stats.detectionRadius)
        {
            currentState = EnemyState.Chase;
        }
        else
        {
            currentState = EnemyState.Idle;
        }
    }
    private void Act(float distance)
    {
        if (player.IsUnityNull()) return;
        switch (currentState)
        {
            case EnemyState.Idle:
                movement.SetMoveDirection(Vector3.zero); // Stop moving
                break;
            case EnemyState.Chase:
                Vector3 direction = (player.position - transform.position).normalized; // Calculate direction to player
                movement.SetMoveDirection(direction); // Move towards the player
                break;
            case EnemyState.Attack:
                movement.SetMoveDirection(Vector3.zero); // Stop moving
                
                if (player.TryGetComponent(out IDamageable damageable))
                {
                    attack.TryAttack(damageable); // Perform attack
                }
                break;
        }

    }
  
}
