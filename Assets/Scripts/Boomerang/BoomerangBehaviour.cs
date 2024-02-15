using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangBehaviour : MonoBehaviour
{
    Rigidbody rb;
    internal GameObject thrower; // le joueur qui ayant lanc� le boomerang
    [SerializeField] 
    float speed; // vitesse du boomerang a l'all�e et au retour
    [SerializeField] 
    float boomTime; // temps que mets le boomerang avant d'atteindre son apog�e dans un premier temps et sa position initiale (un peu plus loin) dans un second temps
    internal bool shouldFly = true; // v�rifie si le boomerang doit voler � l'instanciation ou non
    internal bool isFalling = false;
    float fallTime;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        fallTime = boomTime * 1.1f; // fall time plus long pour qu'un joueur ne bougeant pas puisse r�cup�rer automatiquement un boomerang lanc� au pr�alable
    }
    
    private IEnumerator Start()
    {
        if (shouldFly)
        {
            rb.AddForce(transform.forward * speed); // le boomerang part 
            yield return new WaitForSeconds(boomTime); // attendre
            if (!isFalling)
            {
                rb.velocity = Vector3.zero; // arr�te le boomerang pour ne pas interf�rer avec la force du retour du boomerang
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
            // v�rifie si l 'objet est un joueur
            if (objetTouche == thrower || isFalling)
            {
                // v�rifie si le joueur est le lanceur OU si le boomerang est entrain de tomber et donc inoffenssif
                if (!objetTouche.GetComponent<PlayerBoomerang>().hasBoomerang)
                {
                    objetTouche.SendMessage("PickUp");
                    Destroy(gameObject);
                }
            }
            else
            {
                // si le joueur est un ennemi est que le boomerang est dans les airs, le joueur touch� meurt et le lanceur re�oit 1 point
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
