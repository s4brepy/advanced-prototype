using System;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerInputHandler))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f; // Movement speed of the player

    private Rigidbody2D rb; // Reference to the Rigidbody2D component
    private Vector2 movementInput; // Stores the movement input vector

    private PlayerInputHandler inputHandler; // Reference to the PlayerInputHandler component



    private void Awake() // Called when the script instance is being loaded
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
        inputHandler = GetComponent<PlayerInputHandler>();
      


    }

    private void OnEnable() // Called when the object becomes enabled and active
    {
        
      
    }
    private void OnDisable()
    {
        
        
        inputHandler.InputActions.GamePlay.Move.performed -= OnMove;
        inputHandler.InputActions.GamePlay.Move.canceled -= OnMove;
    }
    private void Start() // Called before the first frame update
    {
        inputHandler.InputActions.GamePlay.Move.performed += OnMove;
        inputHandler.InputActions.GamePlay.Move.canceled += OnMove;
    }

    
    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = movementInput * moveSpeed;
    }
    private void OnMove(InputAction.CallbackContext context)
    { 
       
        movementInput = context.ReadValue<Vector2>().normalized;
    }
}
