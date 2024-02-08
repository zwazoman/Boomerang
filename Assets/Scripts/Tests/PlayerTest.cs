using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    public GameObject boomerang;
    public GameObject boomerangTMP;
    private testBoomerang test;
    public bool hasBoomerang = true;
    void Update()
    {
        if (hasBoomerang)
        {
            if (Input.GetKeyDown("e"))
            {
                print("lance !");
                boomerangTMP = Instantiate(boomerang,transform.forward * 5, transform.rotation);
                test = boomerangTMP.GetComponent<testBoomerang>();
                test.player = this.gameObject;
                hasBoomerang = false;
            }
        }  
    }
    public void ScoreUp()
    {
        print("AUGMENTE LE SCORE");
    }

    void PickUp()
    {
        hasBoomerang = true;
    }
    void Kill()
    {
        Destroy(gameObject);
    }
}
