using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : IInputService
{
    private InputSystem_Actions playerInput;

    public InputHandler()
    {
        playerInput = new InputSystem_Actions();
        playerInput.Player.Enable();
    }

    public Vector2 GetMovementInput()
    {
        return playerInput.Player.Move.ReadValue<Vector2>();
    }

    public bool IsJumpPressed()
    {
        return playerInput.Player.Jump.triggered;
    }

    public bool isFiring()
    {
        return playerInput.Player.Attack.triggered;
    }

    public bool DebugPressed()
    {
        return playerInput.Player.Interact.triggered;
    }

}
    
