using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporteur : MonoBehaviour
{
    public Teleporteur targetTp;
    private GameObject playerToTp;
    private bool canTp;
    private Vector3 targetTpPos;
    private void Awake()
    {
        //player = GameObject.FindWithTag("Player");
        canTp = true;
        targetTpPos = targetTp.transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        playerToTp = other.gameObject;
        Debug.Log("Entrée");
        if (other.gameObject)
        {
            StartCoroutine(TeleportPlayerCoRoutine());
        }

    }

    IEnumerator TeleportPlayerCoRoutine()
    {

        TeleportPlayer();       
        yield return new WaitForSeconds(3);
        DontTeleportPlayer();
    }


  /*  private void OnTriggerExit(Collider other)
    {

        Debug.Log("Sortie");
        if (other.gameObject)
        {
            DontTeleportPlayer();
        }
        playerToTp = null;
    }*/

 private void TeleportPlayer()
    {
        
        if (canTp == true)
        {
            targetTp.canTp = false;
            playerToTp.transform.position = targetTpPos;
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
