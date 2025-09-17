using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;


public enum PlayerState
{
    Walking,
    UsingComputer
}
public class PlayerStateManager : MonoBehaviour
{
    public PlayerState currentState;
    public FirstPersonController firstPersonController;
    public ComputerUseController computerUseController;
    public PlayerInput playerInput;
    
    public bool IsComputerAccessable;

    private void Awake()
    {
        firstPersonController = GetComponent<FirstPersonController>();
        playerInput = GetComponent<PlayerInput>();
        computerUseController = GetComponent<ComputerUseController>();
}

    void Start()
    {
        currentState = PlayerState.Walking;
        Cursor.lockState = CursorLockMode.Locked;
        IsComputerAccessable = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        IsComputerAccessable = true;
        Debug.Log("Computer is accessable");
    }
    private void OnTriggerExit(Collider other)
    {
        IsComputerAccessable = false;
        Debug.Log("Computer is not accesable");
    }

    // Walking action map function 
    public void OnInteract(InputValue lookInput)
    {
        if (IsComputerAccessable) {
            // mkniky cuyc e talis Coroutiny ashateluc heto
            playerInput.SwitchCurrentActionMap("UsingComputer");
            StartCoroutine(firstPersonController.TerminateToComputer());
            Cursor.lockState = CursorLockMode.None;
        }
    }
    // UsingCamera action map function
    public void OnExit(InputValue lookInput)
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerInput.SwitchCurrentActionMap("Walking");
    }

}
