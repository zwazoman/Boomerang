using TMPro;
using UnityEngine;

public class PlayerBoomerang : MonoBehaviour
{
    public GameObject boomerang;
    internal GameObject boomerangTMP;
    BoomerangBehaviour boomScript; // a renommer
    public bool hasBoomerang = true; // le joueur a un boomerang ou non
    public float distanceToInstantiate; // distance à laquelle le boomerang va s'instancier rapport au joueur
    int score; 
    public GameObject objectWithPlayersLists;
    public TextMeshProUGUI scoreText;
    public GameObject Victory_panel;
    [SerializeField] float boomHeight = 0.5f;
    public Animator animator;
    public GameObject deadParticles;

    private void Start()
    {
        hasBoomerang = true;
    }

    internal void ThrowBoomerang(bool _shouldFly = true)
    {
        if (hasBoomerang)
        {
            animator.SetTrigger("BoomrangThrow");
            //AudioManager.Instance.PlayThrow();// joue le son throwSound
            boomerangTMP = Instantiate(boomerang,transform.position + transform.forward * distanceToInstantiate + Vector3.up * boomHeight, transform.rotation); // instanciation du boomerang
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
        if (score == 5)
        {
            Victory_panel.SetActive(true);
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
        // this.gameObject.GetComponent<Player>()
        // Destroy(this.gameObject.GetComponent<Player>().objectWithList.GetComponent<joinDuringGame>().InputPlayerList[this.gameObject.GetComponent<Player>().objectWithList.GetComponent<joinDuringGame>().playerWithController.IndexOf(this.gameObject)]);
        // gameObject.GetComponent<Player>().objectWithList.GetComponent<joinDuringGame>().InputPlayerList[];
        objectWithPlayersLists.GetComponent<joinDuringGame>().playerWithController.Remove(gameObject);
        objectWithPlayersLists.GetComponent<joinDuringGame>().playerWithoutController.Add(gameObject);
        Instantiate(deadParticles);
    }
}