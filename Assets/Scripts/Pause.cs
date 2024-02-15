using UnityEngine;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private GameObject panel_pause;


    public void OnPause(InputAction.CallbackContext _context) //fct qui lance l'�cran de pause
    {
        _playerInput.SwitchCurrentActionMap("UI");
        panel_pause.SetActive(true);
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
        panel_pause.SetActive(false);
    }
}
