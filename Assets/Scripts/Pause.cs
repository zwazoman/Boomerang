using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] internal GameObject panel_pause;
    public GameObject Pause_button;

    public void OnPause(InputAction.CallbackContext _context) //fct qui lance l'écran de pause
    {
        _playerInput.SwitchCurrentActionMap("UI");
        panel_pause.SetActive(true);
        EventSystem.current.SetSelectedGameObject(Pause_button);
        Time.timeScale = 0;
    }

    public void OnPause_desactive()
    {
        _playerInput.SwitchCurrentActionMap("Player");
        Time.timeScale = 1;
        panel_pause.SetActive(false);
    }

    public void Quit(InputAction.CallbackContext _context)
    {
        if (_context.action.triggered && _context.action.name == "Quit")
        {
            
            Application.Quit();
        }
    }
}
