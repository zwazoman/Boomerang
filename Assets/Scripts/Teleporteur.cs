using System.Collections;
using UnityEngine;

public class Teleporteur : MonoBehaviour
{
    public Teleporteur targetTp;
    private GameObject playerToTp;
    private bool canTp;
    private Vector3 targetTpPos;

    private void Awake()
    {
        canTp = true;
        targetTpPos = targetTp.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        playerToTp = other.gameObject;
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

    private void TeleportPlayer()
        {
            if (canTp == true)
            {
                targetTp.canTp = false;
                playerToTp.transform.position = targetTpPos;
            }
        }

    private void DontTeleportPlayer()
    {
        if (canTp == false)
        {
            if (!canTp)
            {
                canTp = true;
            }
        }
    }
}
