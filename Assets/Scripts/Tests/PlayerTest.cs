using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    public GameObject boomerang;
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            Instantiate(boomerang, transform.forward, Quaternion.identity);
        }
    }
}
