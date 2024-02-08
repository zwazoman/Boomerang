using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporteur : MonoBehaviour
{
    public GameObject targetTp;
    private GameObject player;
    public float timeDisable;
    private Collider tpCollider;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        tpCollider = targetTp.GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.transform.position = targetTp.transform.position;
            Debug.Log("tp");
            //targetTp.SetActive(false);
            StartCoroutine(ColliderDisable());
        }
    }
    IEnumerator ColliderDisable()
    {
        tpCollider.enabled = false;
        yield return new WaitForSeconds(timeDisable);
        tpCollider.enabled = true;
    }
}
