using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testBoomerang : MonoBehaviour
{
    Rigidbody rb;
    internal GameObject thrower;
    internal PlayerTest playerScript;
    [SerializeField] float goSpeed = 10;
    [SerializeField] float comeBackSpeed;
    [SerializeField] float boomTime;
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
        rb.velocity = Vector3.zero; // arrête le boomerang pour ne pas interférer avec la force du retour du boomerang
        Vector3 towardsPlayer = (thrower.transform.position - transform.position).normalized * comeBackSpeed; // calcul de la force du retour du boomerang vers la position du lanceur
        rb.AddForce(towardsPlayer); // retour du boomerang
        yield return new WaitForSeconds(fallTime); // attendre
        rb.constraints = RigidbodyConstraints.FreezePositionY; //a marche pas ? / unfreeze la position en z du boomerang pour qu'il tombe au sol + ralentissement ?
    }
    
    public bool IsGrounded() 
    {
        // si le boomerang est en dessous de 1 de hauteur, il est considéré comme au sol
        if (transform.position.y <= 1) return true;
        return false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        // lorsque le boomerang touche une objet
        if (collision.gameObject.tag == "Player")
        {
            // vérifie si l 'objet est un joueur
            if (collision.gameObject == thrower || IsGrounded())
            {
                // vérifie si le joueur est le lanceur OU si le boomerang est au sol et donc inoffenssif
                collision.gameObject.SendMessage("PickUp");
                Destroy(gameObject);
            }
            else
            {
                // si le joueur est un ennemi est que le boomerang est dans les airs, le joueur touché meurt et le lanceur reçoit 1 point
                collision.gameObject.SendMessage("Kill");
                thrower.GetComponent<PlayerTest>().ScoreUp();
            }
        }
    }
}
