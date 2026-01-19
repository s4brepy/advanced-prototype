using System;
using UnityEngine;

public class DamageDummy : MonoBehaviour, IDamageable // A simple damageable dummy for testing
{
    [SerializeField] private int health = 50; // Initial health of the dummy

    public void TakeDamage(int amount) // Implementation of IDamageable interface
    {
        health -= amount; // Reduce health by the damage amount
        
        if ( health <= 0) // Check if health is depleted
        {
            
            Destroy(gameObject); // Destroy the dummy object
        }
    }

  
}
