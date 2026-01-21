using Unity.Jobs;
using Unity.VisualScripting;
using Unity.VisualScripting.InputSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // Singleton instance
    public static GameStates CurrentState { get; private set; } // Current game state
    private GameStates trackState;

    private PlayerInputHandler inputHandler; // Reference to the PlayerInputHandler component

    [SerializeField] private GameObject pause;
    [SerializeField] private GameObject gameover;
    private bool isGameOver = false;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject); // Ensure only one instance exists
            return;

        }
        Instance = this; // Assign the singleton instance

        inputHandler = GetComponent<PlayerInputHandler>();

        
 

    }

    private void Start()
    {

        if (SceneManager.GetActiveScene().name == "GAMEPLAY")
        {
            SetState(GameStates.PLAYING);
            inputHandler.InputActions.GamePlay.Pause.performed += OnPause;


        }



    }

    private void Update()     
    {
       if (CurrentState == GameStates.GAMEOVER && isGameOver == false) { GameOver();}
       
    }
    

    public void SetState(GameStates newState)
    {
        if (CurrentState == newState)
            return; // No state change

        CurrentState = newState;
        Debug.Log($"Game state changed to: {CurrentState}");
        // Additional logic for state transitions can be added here
    }

    public void SetPlay() 
    { 
        SetState(GameStates.PLAYING);
        SceneManager.LoadScene("GAMEPLAY");
        Time.timeScale = 1.0f;
    }


    private void OnPause(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        Debug.Log(CurrentState);
        if (CurrentState == GameStates.PLAYING)
        {
            SetState(GameStates.PAUSED);
            Time.timeScale = 0f; // Pause the game
           
            pause.SetActive(true);
            Debug.Log("Game Paused");

        }
        else if (CurrentState == GameStates.PAUSED)
        {
            SetState(GameStates.PLAYING);
            Time.timeScale = 1f; // Resume the game
            
            pause.SetActive(false);
            Debug.Log("Game Resumed");
        }
    }

    private void GameOver() 
    {
        
        gameover.SetActive(true);
        Time.timeScale = 0; 
        isGameOver = true;
        inputHandler.InputActions.GamePlay.Pause.performed -= OnPause;
        inputHandler.InputActions.GamePlay.Disable();
    }

    private void OnDisable()
    {
       
    }

}
