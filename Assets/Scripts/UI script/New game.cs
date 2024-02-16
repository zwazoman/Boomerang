using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Newgame : MonoBehaviour// Script qui permet de gérer les actions lorsque le joueur press le bouton New Game
{
    [SerializeField] private PlayerInput _playerInput;

    public GameObject cameraVirtuel;
    public GameObject NewGame;

    public void Start()
    {
        EventSystem.current.SetSelectedGameObject(NewGame);// Au start, L'event system prends le bouton New Game pour permettre de naviguer dans les menus
    }

    public void New_Game()
    {
        cameraVirtuel.SetActive(true); // Lorsque le bouton est presser, la camera change automatiquement la vue
    }
}
