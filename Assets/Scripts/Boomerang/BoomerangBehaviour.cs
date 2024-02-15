using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangBehaviour : MonoBehaviour
{
    Rigidbody rb;
    internal GameObject thrower; // le joueur qui ayant lancé le boomerang
    [SerializeField] 
    float speed; // vitesse du boomerang a l'allée et au retour
    [SerializeField] 
    float boomTime; // temps que mets le boomerang avant d'atteindre son apogée dans un premier temps et sa position initiale (un peu plus loin) dans un second temps
    internal bool shouldFly = true; // vérifie si le boomerang doit voler à l'instanciation ou non
    internal bool isFalling = false;
    float fallTime;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        fallTime = boomTime * 1.1f; // fall time plus long pour qu'un joueur ne bougeant pas puisse récupérer automatiquement un boomerang lancé au préalable
    }
    
    private IEnumerator Start()
    {
        if (shouldFly)
        {
            rb.AddForce(transform.forward * speed); // le boomerang part 
            yield return new WaitForSeconds(boomTime); // attendre
            if (!isFalling)
            {
                rb.velocity = Vector3.zero; // arrête le boomerang pour ne pas interférer avec la force du retour du boomerang
                Vector3 towardsPlayer = (thrower.transform.position - transform.position).normalized * speed; // calcul de la force du retour du boomerang vers la position du lanceur
                rb.AddForce(towardsPlayer); // retour du boomerang
                yield return new WaitForSeconds(fallTime); // attendre
                FallBoomerang();
            }
        }
        else
        {
            FallBoomerang();
        }
    }
    private void Update()
    {
        if (!thrower.activeInHierarchy)
        {
            FallBoomerang();
        }
    }

    void FallBoomerang()
    {
        rb.useGravity = true; //le boomerang tombe au sol
        isFalling = true;
        // ne plus se servir de isGrounded mais de is falling plutot ? plus propre et pas de raycast.
    }

    private void OnCollisionEnter(Collision collision)
    {
        // lorsque le boomerang touche une objet
        GameObject objetTouche = collision.gameObject;
        print(objetTouche);
        if (objetTouche.tag == "Player")
        {
            // vérifie si l 'objet est un joueur
            if (objetTouche == thrower || isFalling)
            {
                // vérifie si le joueur est le lanceur OU si le boomerang est entrain de tomber et donc inoffenssif
                if (!objetTouche.GetComponent<PlayerBoomerang>().hasBoomerang)
                {
                    objetTouche.SendMessage("PickUp");
                    Destroy(gameObject);
                }
            }
            else
            {
                // si le joueur est un ennemi est que le boomerang est dans les airs, le joueur touché meurt et le lanceur reçoit 1 point
                collision.gameObject.SendMessage("Kill");
                thrower.GetComponent<PlayerBoomerang>().ScoreUp();
            }
        }
        if(objetTouche.layer == 3 || objetTouche.layer == 7)
        {
            FallBoomerang();
        }
    }
}
