using System.Collections.Generic;
using UnityEngine;

public class RecupBoomerang : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab_Boomerang;
    public List<GameObject> spawnPoint_Boomerang;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boomerang")
        {
            other.transform.position = spawnPoint_Boomerang[Random.Range(0, spawnPoint_Boomerang.Count)].transform.position;
        }

        if (other.gameObject.tag == "Player")
        {
            other.transform.position = spawnPoint_Boomerang[Random.Range(0, spawnPoint_Boomerang.Count)].transform.position;
        }
    }
}
