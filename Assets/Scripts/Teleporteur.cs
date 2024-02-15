using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporteur : MonoBehaviour
{
    public Teleporteur targetTp;
    private GameObject player;
    private bool canTp;
    private Vector3 targetTpPos;
    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        canTp = true;
        targetTpPos = targetTp.transform.position;
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
            targetTp.canTp = false;
            player.transform.position = targetTpPos;
            Debug.Log("tp");
        }
    }

    private void DontTeleportPlayer()
    {
        if (canTp == false)
        {
            Debug.Log("Desactivé");
            if (!canTp)
                canTp = true;
        }
    }
}
