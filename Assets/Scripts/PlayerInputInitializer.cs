using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputInitializer : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel;
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private GameObject boomerangPrefabToGive;


    private void Awake()
    {
        GetComponent<PlayerInputManager>().onPlayerJoined += OnPlayerJoined;
    }

    private void OnPlayerJoined(PlayerInput obj)
    {
        obj.GetComponent<Pause>().PanelPause = pausePanel;
        obj.GetComponent<PlayerBoomerang>().scoreText = score;
        obj.GetComponent<PlayerBoomerang>().boomerang = boomerangPrefabToGive;
    }
}
