using UnityEngine;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
    [SerializeField]
    private PlayerInput _playerInput;
    [SerializeField]
    private GameObject panel_pause;
    [SerializeField]
    private GameObject imageUp;
    [SerializeField]
    private GameObject imageDown;

    public void OnPause(InputAction.CallbackContext _context) //fct qui lance l'écran de pause
    {
        _playerInput.SwitchCurrentActionMap("UI");
        panel_pause.SetActive(true);
        Time.timeScale = 0;
    }

    public void ScrollMenuUp(InputAction.CallbackContext _context)//fct qui change l'affichage du joueur pour naviguer dans les menus
    {
        imageUp.SetActive(true);
        imageDown.SetActive(false);
        Accept(_context);
    }

    public void ScrollMenuDown(InputAction.CallbackContext _context)//fct qui change l'affichage du joueur pour naviguer dans les menus
    {
        imageDown.SetActive(true);
        imageUp.SetActive(false);
        Quit(_context);
    }

    public void Accept(InputAction.CallbackContext _context)
    {
        if (_context.action.triggered && _context.action.name == "Accept")
        {
            OnEscape(_context);
        }
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
