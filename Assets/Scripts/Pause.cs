using UnityEngine;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] public GameObject PanelPause;


    public void OnPause(InputAction.CallbackContext _context) //fct qui lance l'écran de pause
    {
        _playerInput.SwitchCurrentActionMap("UI");
        PanelPause.SetActive(true);
        Time.timeScale = 0;
    }

    public void Quit(InputAction.CallbackContext _context)
    {
        Debug.Log("A");
        if (_context.action.triggered && _context.action.name == "Quit")
        {
            Debug.Log(_context.action.triggered);
            Application.Quit();
        }
    }

    public void OnEscape(InputAction.CallbackContext _context)//Fct raccourcie qui permet de revenir au jeu rapidement
    {
        _playerInput.SwitchCurrentActionMap("Player");
        Time.timeScale = 1;
        PanelPause.SetActive(false);
    }
}
