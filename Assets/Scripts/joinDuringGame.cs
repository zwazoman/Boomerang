using System.Collections.Generic;
using UnityEngine;

public class joinDuringGame : MonoBehaviour
{
    public List<GameObject> playerWithoutController;
    public List<GameObject> playerWithController;
    public List<GameObject> spawnPoint;
    public List<GameObject> InputPlayerList;

    public Player OnJoin()
    {
        if (playerWithoutController.Count > 0)
        {
            GameObject PlayerEntering = playerWithoutController[0]; 
            playerWithoutController.RemoveAt(0);
            playerWithController.Add(PlayerEntering);
            PlayerEntering.SetActive(true);
            PlayerEntering.transform.position = spawnPoint[Random.Range(0, spawnPoint.Count)].transform.position;
            return PlayerEntering.GetComponent<Player>();
        }

        return null;
    }
}
