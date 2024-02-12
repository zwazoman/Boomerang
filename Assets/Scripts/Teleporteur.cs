using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporteur : MonoBehaviour
{
    public GameObject targetTp;
    private GameObject player;
    private bool canTp;
    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        canTp = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            TeleportPlayer();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {            
            DontTeleportPlayer();
        }
    }

   
    private void TeleportPlayer()
    {
        if (canTp == true)
        {
            canTp = false;
            player.transform.position = targetTp.transform.position;
            Debug.Log("tp");
        }
    }

    private void DontTeleportPlayer()
    {
        if (canTp == false)
        {
            Debug.Log("Desactivé");
            canTp = true;
        }
    }
}
