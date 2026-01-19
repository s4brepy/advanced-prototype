using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInputHandler))]
[RequireComponent(typeof(PlayerCombat))]

public class PlayerAttackInput : MonoBehaviour
{
    

    public PlayerInputHandler inputHandler;
    private PlayerCombat combat;

    private void Awake()
    {
        inputHandler = GetComponent<PlayerInputHandler>();
        combat = GetComponent<PlayerCombat>();
        
    }
    private void OnEnable()
    {
        

        
    }
    private void Start()
    {
        inputHandler.InputActions.GamePlay.Attack.performed += OnAttack;
    }
    private void OnDisable()
    {
        inputHandler.InputActions.GamePlay.Attack.performed -= OnAttack;
    }
    private void OnAttack(InputAction.CallbackContext context)
    {
        
        combat.TryAttack();
        
    }

}
