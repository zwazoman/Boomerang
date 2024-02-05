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
        Time.timeScale = 0;
        panel_pause.SetActive(true);
    }

    public void OnEscape(InputAction.CallbackContext _context)
    {
        //playerInput.SwitchCurrentActionMap("UI");
        Time.timeScale = 1;
        panel_pause.SetActive(false);
    }

}
