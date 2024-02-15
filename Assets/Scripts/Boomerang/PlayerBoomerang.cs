using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerBoomerang : MonoBehaviour
{
    public GameObject boomerang;
    internal GameObject boomerangTMP;
    BoomerangBehaviour boomScript; // a renommer
    internal bool hasBoomerang = true; // le joueur a un boomerang ou non
    public float distanceToInstantiate;
    int score;
    public GameObject objectWithPlayersLists;
    public TextMeshProUGUI scoreText;

    internal void ThrowBoomerang(bool _shouldFly = true)
    {
        if (hasBoomerang)
        {
            print("lance !"); // a retirer
            boomerangTMP = Instantiate(boomerang,transform.position + transform.forward * distanceToInstantiate, transform.rotation); // instanciation du boomerang
            boomScript = boomerangTMP.GetComponent<BoomerangBehaviour>(); // a renommer 
            boomScript.thrower = this.gameObject;
            boomScript.shouldFly = _shouldFly;
            hasBoomerang = false;
        }
    }

    public void ScoreUp()
    {
        // augmente le score quand le message "ScoreUp()" est reçu
        score += 1;
        print(score); // a retirer
        if (score == 5)
        {
            gameObject.transform.localScale *= 10;
            Time.timeScale = 0;
            scoreText.text = (score + "/5");
        }
    }

    public void PickUp()
    {
        // ramasse le boomerang quand le message "PickUp()" est reçu
        print("RAMASSE"); // a retirer
        hasBoomerang = true;
    }
    public void Kill()
    {
        ThrowBoomerang(false);
        gameObject.SetActive(false);
        objectWithPlayersLists.GetComponent<joinDuringGame>().playerWithController.Remove(gameObject);
        objectWithPlayersLists.GetComponent<joinDuringGame>().playerWithoutController.Add(gameObject);
    }
}
