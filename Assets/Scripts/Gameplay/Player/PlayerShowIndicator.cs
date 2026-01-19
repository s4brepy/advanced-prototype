using UnityEngine;
using System.Collections;
public class ShowIndicator : MonoBehaviour 
{

    [SerializeField] private GameObject indicator;
    [SerializeField] private float indicatorDuration = 2f;

    public PlayerInputHandler inputHandler;

    private void Awake()
    {
        inputHandler = GetComponent<PlayerInputHandler>();
    }
    private void Start()
    {
        inputHandler.InputActions.GamePlay.Attack.performed += OnAttack;

    }
    private void OnDisable()
    {
        inputHandler.InputActions.GamePlay.Attack.performed -= OnAttack;

    }
    public IEnumerator Show()
    {
        //Debug.Log("Showing Indicator");
        indicator.SetActive(true);
        yield return new WaitForSeconds(indicatorDuration);
        indicator.SetActive(false);
    }
    private void OnAttack(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        StartCoroutine(Show());
    }

}
