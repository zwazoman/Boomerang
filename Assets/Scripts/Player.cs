using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Vector2 InputValue;

    public void InputPlayer(InputAction.CallbackContext _context)
    {
        InputValue = _context.ReadValue<Vector2>();
    }

    private void Update()
    {
        Vector3 mouvement = new Vector3(InputValue.x, 0, InputValue.y);
        mouvement.Normalize();
        transform.Translate(speed * mouvement * Time.deltaTime);
    }
}
