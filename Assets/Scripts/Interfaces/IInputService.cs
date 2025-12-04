using UnityEngine;

public interface IInputService
{
    Vector2 GetMovementInput();
    bool IsJumpPressed();
    bool isFiring();
    bool DebugPressed();
}
