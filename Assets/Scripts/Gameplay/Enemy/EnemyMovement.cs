using System.Collections;
using Unity.AppUI.UI;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private EnemyStats stats;

    [SerializeField] private float knockbackForce = 5f;
    [SerializeField] private float knockbackDuration = 0.1f;
    private bool isKnockedBack;
    
    private Rigidbody2D rb; // Reference to the Rigidbody2D component
    private Vector3 moveDirection; // Direction in which the enemy moves

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
        

    }
    public void SetMoveDirection(Vector3 direction) // Method to set the movement direction
    { 
        moveDirection = direction.normalized; // Normalize the direction vector
    }
    private void FixedUpdate()
    {
        if (isKnockedBack) return;
        rb.linearVelocity = moveDirection*stats.moveSpeed; // Move the enemy in the specified direction
    }
    public void ApplyKnockback(Vector2 direction)
    {
        if (isKnockedBack) return;
        StartCoroutine(KnockbackRoutine(direction));
    }

    private IEnumerator KnockbackRoutine(Vector2 direction)
    {
        isKnockedBack = true;

        rb.linearVelocity = Vector2.zero;
        rb.AddForce(direction.normalized * knockbackForce,ForceMode2D.Impulse);
        yield return new WaitForSeconds(knockbackDuration);
        isKnockedBack=false;
    }
}
