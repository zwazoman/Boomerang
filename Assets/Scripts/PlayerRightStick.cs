using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRightStick : MonoBehaviour
{
    [SerializeField]
    protected Vector2 Input_Value_Rotation;
    [SerializeField]
    protected float sensibility = 5f;

    public void RotationPlayer(InputAction.CallbackContext _context)
    {
        Vector2 input = _context.ReadValue<Vector2>();
        float rotation = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0f, rotation, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, sensibility * Time.deltaTime);
    }
}
