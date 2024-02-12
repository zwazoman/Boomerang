using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangBehaviour : MonoBehaviour
{
    Rigidbody rb;
    internal GameObject thrower;
    [SerializeField] 
    float goSpeed;
    [SerializeField] 
    float comeBackSpeed;
    [SerializeField] 
    float boomTime;
    internal bool isGrounded = false;
    internal bool isFalling = false;
    float fallTime;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        fallTime = boomTime * 1.1f; // fall time plus long pour qu'un joueur ne bougeant pas puisse récupérer automatiquement un boomerang lancé au préalable
    }
    
    private IEnumerator Start()
    {
        rb.AddForce(transform.forward * goSpeed); // le boomerang part 
        yield return new WaitForSeconds(boomTime); // attendre
        if (!isFalling)
        {

            rb.velocity = Vector3.zero; // arrête le boomerang pour ne pas interférer avec la force du retour du boomerang
            Vector3 towardsPlayer = (thrower.transform.position - transform.position).normalized * comeBackSpeed; // calcul de la force du retour du boomerang vers la position du lanceur
            rb.AddForce(towardsPlayer); // retour du boomerang
            yield return new WaitForSeconds(fallTime); // attendre
            FallBoomerang();
        }
        
    }
    private void Update()
    {
        if (Physics.Raycast(transform.position, -transform.up, 0.1f))
        {
            isGrounded = true;
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
        if(objetTouche.layer == 3)
        {
            // si l'objet touché possède le layer "WALL" et est un mu
            FallBoomerang();
        }
    }
}
