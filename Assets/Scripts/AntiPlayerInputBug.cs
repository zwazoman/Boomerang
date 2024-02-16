using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiPlayerInputBug : MonoBehaviour
{
    public GameObject objectWithList;
    public bool isAttributeToPLayer;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("AntiBugStart");
        objectWithList = FindAnyObjectByType<Player>().GetComponent<Player>().objectWithList;
        objectWithList.GetComponent<joinDuringGame>().InputPlayerList.Add(gameObject);
    }
}
