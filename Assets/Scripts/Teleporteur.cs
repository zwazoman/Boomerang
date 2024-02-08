using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporteur : MonoBehaviour
{
    public GameObject targetTp;
    private GameObject player;
    public float timeDisable;
    private Collider tpCollider;
    private bool canTp;
    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        tpCollider = targetTp.GetComponent<Collider>();
        canTp = true;
    }

    private void Update()
    {
        if (canTp == false)
        {
            targetTp.SetActive(false);
        }
        else if (canTp == true)
                {
                targetTp.SetActive(true);
                }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.transform.position = targetTp.transform.position;
            Debug.Log("tp");
            
            //StartCoroutine(ColliderDisable());
            canTp = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            
            Debug.Log("tpActive");
            
            //StartCoroutine(ColliderDisable());
            canTp = true;
        }
    }
    /*IEnumerator ColliderDisable()
    {
        tpCollider.enabled = false;
        yield return new WaitForSeconds(timeDisable);
        tpCollider.enabled = true;
    }*/
}
