using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    public GameObject boomerang;
    public GameObject boomerangTMP;
    private BoomerangBehaviour throwScript; // a renommer
    public bool hasBoomerang = true; // le joueur a un boomerang ou non
    public float distanceToInstantiate;
    void Update()
    {
        if (hasBoomerang)
        {
            if (Input.GetKeyDown("e"))
            {
                print("lance !"); // a retirer
                boomerangTMP = Instantiate(boomerang,transform.position + transform.forward * distanceToInstantiate, transform.rotation); // instanciation du boomerang
                throwScript = boomerangTMP.GetComponent<BoomerangBehaviour>(); // a renommer 
                throwScript.thrower = this.gameObject;
                hasBoomerang = false;
            }
        }  
    }
    public void ScoreUp()
    {
        // augmente le score quand le message "ScoreUp()" est reçu
        print("AUGMENTE LE SCORE"); // a retirer
    }

    public void PickUp()
    {
        // ramasse le boomerang quand le message "PickUp()" est reçu
        print("RAMASSE"); // a retirer
        hasBoomerang = true;
    }
    public void Kill()
    {
        // détruit le joueur quand "Kill()" est reçu
        Destroy(gameObject);
    }
}
