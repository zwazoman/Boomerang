using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class joinDuringGame : MonoBehaviour
{
    public List<GameObject> playerWithoutController;
    public List<GameObject> playerWithController;
    public List<GameObject> spawnPoint;
    public GameObject lastPlayerEnter;

    public void OnJoin(InputAction.CallbackContext _context)
    {
        if (_context.started)
        {
            Debug.Log("Joining");
            if (playerWithoutController.Count > 0)
            {
                GameObject PlayerEntering = playerWithoutController[0];
                playerWithoutController.RemoveAt(0);
                playerWithController.Add(PlayerEntering);
                PlayerEntering.SetActive(true);
                PlayerEntering.transform.position = spawnPoint[Random.Range(0, spawnPoint.Count)].transform.position;
                lastPlayerEnter = PlayerEntering;
            }
        }
    }
}
