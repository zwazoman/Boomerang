using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Input : MonoBehaviour
{

    public Player player;//Référence au Script Player (c'est le PlayerBehaviour)
    public GameObject objectWhoGivePlayer;
    [SerializeField]
    public PlayerBoomerang boomerangManager;

    private void Start()
    {
        player = FindAnyObjectByType<joinDuringGame>().OnJoin();
    }

    public void OnInputPlayer(InputAction.CallbackContext _context)
    {
        player.InputValue = _context.ReadValue<Vector2>();
    }

    public void RotationPlayer(InputAction.CallbackContext _context)
    {
        player._context = _context.ReadValue<Vector2>();
        player.Rotation();
    }

    public void OnThrow(InputAction.CallbackContext _context)
    {
        player.boomerangManager.ThrowBoomerang();
    }
}
