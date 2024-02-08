using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class Pause : MonoBehaviour
{
    [SerializeField]
    private PlayerInput _playerInput;
    [SerializeField]
    private GameObject panel_pause;
    public GameObject objectWhoGivePlayerInstance;
    public Player player;

    private void Start()
    {
        player = objectWhoGivePlayerInstance.GetComponent<joinDuringGame>().lastPlayerEnter.GetComponent<Player>();
    }

    public void OnPause(InputAction.CallbackContext _context)
    {
        Debug.Log("b");
        _playerInput.SwitchCurrentActionMap("UI");
        panel_pause.SetActive(true);
        Time.timeScale = 0;
    }

    public void OnEscape(InputAction.CallbackContext _context)
    {
        Debug.Log("b");
        _playerInput.SwitchCurrentActionMap("Player");
        Time.timeScale = 1;
        panel_pause.SetActive(false);
    }
    public void OnInputPlayer(InputAction.CallbackContext _context)
    {
        player.InputValue = _context.ReadValue<Vector2>();
    }

}
