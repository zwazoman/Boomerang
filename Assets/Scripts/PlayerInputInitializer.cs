using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputInitializer : MonoBehaviour
{
    [SerializeField]
    private GameObject PausePanel;

    private void Awake()
    {
        GetComponent<PlayerInputManager>().onPlayerJoined += OnPlayerJoined;
    }

    private void OnPlayerJoined(PlayerInput obj)
    {
        obj.GetComponent<Pause>().PanelPause = PausePanel;
    }
}
