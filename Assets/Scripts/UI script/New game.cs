using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class Newgame : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;

    public GameObject cameraVirtuel;
    public void New_Game()
    {
        _playerInput.SwitchCurrentActionMap("Player");
        cameraVirtuel.SetActive(true);
    }
}
