using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testBoomerang : MonoBehaviour
{
    Rigidbody rb;
    internal GameObject player;
    internal PlayerTest playerScript;
    [SerializeField] float goSpeed = 10;
    [SerializeField] float comeBackSpeed;
    [SerializeField] float boomTime;
    float fallTime;
    Vector3 backSpot;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        fallTime = boomTime * 1.1f;
        //playerScript = player.GetComponent<PlayerTest>();
    }
    
    private IEnumerator Start()
    {
        playerScript = player.GetComponent<PlayerTest>();
        rb.AddForce(transform.forward * goSpeed);
        yield return new WaitForSeconds(boomTime);
        rb.velocity = Vector3.zero;
        backSpot = player.transform.position;
        Vector3 backDirection = backSpot - transform.position;
        rb.AddForce((player.transform.position - transform.position).normalized * comeBackSpeed);
        yield return new WaitForSeconds(fallTime);
        rb.constraints = RigidbodyConstraints.FreezePositionZ;
    }
    
    public bool IsGrounded()
    {
        if (transform.position.y <= 1) return true;
        return false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject == player || IsGrounded())
            {
                collision.gameObject.SendMessage("PickUp");
                Destroy(gameObject);
            }
            else
            {
                collision.gameObject.SendMessage("Kill");
                playerScript.ScoreUp();
            }
        }
    }
}
