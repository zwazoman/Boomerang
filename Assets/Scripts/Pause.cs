using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{

    [SerializeField]
    private GameObject panel_pause;
    public void OnPause(InputAction.CallbackContext _context)
    {
        //playerInput.SwitchCurrentActionMap("UI");
        panel_pause.SetActive(true);
    }

    public void OnEscape(InputAction.CallbackContext _context)
    {
        //playerInput.SwitchCurrentActionMap("UI");
        panel_pause.SetActive(false);
    }

}
