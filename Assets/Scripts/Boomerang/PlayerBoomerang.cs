using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoomerang : MonoBehaviour
{
    public GameObject boomerang;
    internal GameObject boomerangTMP;
    BoomerangBehaviour boomScript; // a renommer
    [SerializeField] DashManager dashScript;
    internal bool hasBoomerang = true; // le joueur a un boomerang ou non
    public float distanceToInstantiate;
    int score;
    public GameObject objectWithPlayersLists;
    
    internal void ThrowBoomerang()
    {
        if (hasBoomerang)
        {
            print("lance !"); // a retirer
            boomerangTMP = Instantiate(boomerang,transform.position + transform.forward * distanceToInstantiate, transform.rotation); // instanciation du boomerang
            boomScript = boomerangTMP.GetComponent<BoomerangBehaviour>(); // a renommer 
            boomScript.thrower = this.gameObject;
            hasBoomerang = false;
        }
    }

    internal void Dash()
    {
        if (!hasBoomerang)
        {
            print("ALLEZ");
            dashScript.StartCoroutine("Dash");
        }
    }

    public void ScoreUp()
    {
        // augmente le score quand le message "ScoreUp()" est re�u
        print("AUGMENTE LE SCORE"); // a retirer
        score += 1;
        if (score == 5)
        {
            gameObject.transform.localScale *= 10;
            Time.timeScale = 0;
        }
    }

    public void PickUp()
    {
        // ramasse le boomerang quand le message "PickUp()" est re�u
        print("RAMASSE"); // a retirer
        hasBoomerang = true;
    }
    public void Kill()
    {
        // d�truit le joueur quand "Kill()" est re�u
        Debug.Log("Player death");
        gameObject.SetActive(false);
        objectWithPlayersLists.GetComponent<joinDuringGame>().playerWithController.Remove(gameObject);
        objectWithPlayersLists.GetComponent<joinDuringGame>().playerWithoutController.Add(gameObject);
        
    }
}
