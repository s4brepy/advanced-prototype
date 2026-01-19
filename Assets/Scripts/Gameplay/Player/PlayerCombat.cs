using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    
    


    [SerializeField] private int damage = 10; // Damage per attack
    [SerializeField] private float attackRadius = 0.5f; // Radius of the attack area
    public float attackCooldown { get; private set; } = 0.5f;  // Cooldown between attacks
    [SerializeField] private LayerMask damageableLayer; // Layer for damageable objects

    

    private float lastAttackTime; // Time of the last attack
   
    private bool CanAttack => Time.time >= lastAttackTime + attackCooldown; // Check if the player can attack



    public void TryAttack()// Called when the attack input is performed
    { 
      if (!CanAttack) return;
        lastAttackTime = Time.time; // Update the last attack time
        PerformAttack(); // Execute the attack
    }

    private void PerformAttack() // Execute the attack logic
    {
        

        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, attackRadius, damageableLayer); // Detect damageable objects in range


        foreach (Collider2D hit in hits) // Iterate through detected objects
        {
            if (hit.TryGetComponent<IDamageable>(out IDamageable damageable)) // Check if the object is damageable
            {
                damageable.TakeDamage(damage); // Apply damage to the object
                //Debug.Log($"Dealt {damage} damage to {hit.name}"); // Log the damage dealt
            }
        }
       
    }

}

