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
    public float distanceToInstantiate; // distance à laquelle le boomerang va s'instancier rapport au joueur
    int score; 
    public GameObject objectWithPlayersLists;
    public TextMeshProUGUI scoreText;

    internal void ThrowBoomerang(bool _shouldFly = true)
    {
        if (hasBoomerang)
        {
            AudioManager.Instance.PlayThrow();// joue le son throwSound
            boomerangTMP = Instantiate(boomerang,transform.position + transform.forward * distanceToInstantiate, transform.rotation); // instanciation du boomerang
            boomScript = boomerangTMP.GetComponent<BoomerangBehaviour>();
            boomScript.thrower = this.gameObject;
            boomScript.shouldFly = _shouldFly; // donne l'information que le boomerang vole ou simplement tombe au sol
            hasBoomerang = false;
        }
    }

    public void ScoreUp()
    {
        // augmente le score quand le message "ScoreUp()" est reçu
        score += 1;
        scoreText.text = (score + "/5");
        print(score); // a retirer
        if (score == 5)
        {
            // Victoire du joueur actuel 
            
        }
    }

    public void PickUp()
    {
        // ramasse le boomerang quand le message "PickUp()" est reçu
        AudioManager.Instance.PlayCatch(); // joue le son "catchSound"
        hasBoomerang = true;
    }
    public void Kill()
    {
        ThrowBoomerang(false); // jette le boomerang au pieds du joueur mourrant
        AudioManager.Instance.PlayDie(); // joue le son de mort
        gameObject.SetActive(false);
        objectWithPlayersLists.GetComponent<joinDuringGame>().playerWithController.Remove(gameObject);
        objectWithPlayersLists.GetComponent<joinDuringGame>().playerWithoutController.Add(gameObject);
    }
}
