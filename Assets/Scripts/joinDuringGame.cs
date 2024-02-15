using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class joinDuringGame : MonoBehaviour
{
    public List<GameObject> playerWithoutController;
    public List<GameObject> playerWithController;
    public List<GameObject> spawnPoint;
    public List<GameObject> InputPlayerList;

    public Player OnJoin()
    {
        Debug.Log("Trying to join");
        if (playerWithoutController.Count > 0)
        {
            GameObject PlayerEntering = playerWithoutController[0]; 
            playerWithoutController.RemoveAt(0); Debug.Log("Player remove from without player with controller list");
            playerWithController.Add(PlayerEntering); Debug.Log("Player add to player with controller list");
            PlayerEntering.SetActive(true); Debug.Log("Player appear");
            PlayerEntering.transform.position = spawnPoint[Random.Range(0, spawnPoint.Count)].transform.position; Debug.Log("position set");
            Debug.Log("Join succes");
            Debug.Log(playerWithController.Count);
            return PlayerEntering.GetComponent<Player>();

        }
    return null;
    }

    private void Update()
    {
        Debug.Log((playerWithController.Count, "from script joinDuringGame"));
    }
}
