using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Input : MonoBehaviour
{

    public Player player;

    public void OnInputPlayer(InputAction.CallbackContext _context)
    {
        player.InputValue = _context.ReadValue<Vector2>();
    }

    public void RotationPlayer(InputAction.CallbackContext _context)
    {
        player._context = _context.ReadValue<Vector2>();
        player.Rotation();
    }
}
