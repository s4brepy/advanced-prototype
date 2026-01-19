using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // Singleton instance
    public GameStates CurrentState { get; private set; } // Current game state

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject); // Ensure only one instance exists
            return;

        }
        Instance = this; // Assign the singleton instance
        DontDestroyOnLoad(gameObject); // Persist across scenes
    }

    private void Start()
    {
        SetState(GameStates.BOOT); // Initial state
    }

    public void SetState(GameStates newState)
    {
        if (CurrentState == newState)
            return; // No state change

        CurrentState = newState;
        Debug.Log($"Game state changed to: {newState}");
        // Additional logic for state transitions can be added here
    }
}
