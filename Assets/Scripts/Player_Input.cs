using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Input : MonoBehaviour
{

    public Player player;//Référence au Script Player (c'est le PlayerBehaviour)
    public DashManager dashScript;
    public PlayerBoomerang boomerangManager;

    private void Start()
    {
        player = FindAnyObjectByType<joinDuringGame>().OnJoin();
        boomerangManager = player.GetComponent<PlayerBoomerang>();
        
    }

    public void OnInputPlayer(InputAction.CallbackContext _context)
    {
        player.InputValue = _context.ReadValue<Vector2>();
        dashScript.InputValue = _context.ReadValue<Vector2>();
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

    public void OnDash(InputAction.CallbackContext _context)
    {
        if (_context.started)
        {
            player.boomerangManager.Dash();
        }

    }

    public void FindPlayerWithoutChildInputPlayer()
    {
        foreach (GameObject PlayerWithController in FindAnyObjectByType<joinDuringGame>().playerWithController)
        {
            if (PlayerWithController != null)
            {

            }
        }
    }
}
