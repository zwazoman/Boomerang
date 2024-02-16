using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class Newgame : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;

    public GameObject cameraVirtuel;
    public GameObject NewGame;

    public void Start()
    {
        EventSystem.current.SetSelectedGameObject(NewGame);
    }
    public void New_Game()
    {
        cameraVirtuel.SetActive(true);
    }
}
