using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testBoomerang : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] GameObject player;
    [SerializeField] float goSpeed = 10;
    [SerializeField] float comeBackSpeed;
    [SerializeField] float boomTime;
    Vector3 backSpot;
    Vector3 target;

    private void Awake()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
    }
    
    private IEnumerator Start()
    {
        rb.AddForce(transform.forward * goSpeed);
        yield return new WaitForSeconds(boomTime);
        rb.AddForce(-transform.forward * goSpeed);
        backSpot = player.transform.position;
        Vector3 backDirection = backSpot - transform.position;
        rb.AddForce((player.transform.position - transform.position).normalized * comeBackSpeed);
        
        //Vector3 offset = player.transform.position - transform.position;
        //transform.rotation = Quaternion.Euler(new Vector3(0,Mathf.Rad2Deg * Mathf.Atan2(offset.x, offset.z), 0));
       //rb.velocity = Vector3.zero;
    }
    private void Update()
    {
        /*if(transform.position == backSpot)
        {
            rb.useGravity = true;
        }*/
        //rb.AddForce(transform.forward * goSpeed); // * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
       // collision.gameObject.SendMessage("BoomerangTouched");
    }
}
