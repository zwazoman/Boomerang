using UnityEngine;
using UnityEngine.InputSystem;

public class Pause_active : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    public void OnPause_active()
    {
        Time.timeScale = 0;
    }

    public void OnPause_desactive()
    {
        Time.timeScale = 1;
        _playerInput.SwitchCurrentActionMap("Player");
    }
}
