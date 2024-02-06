using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testBoomerang : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] GameObject player;
    [SerializeField] float goSpeed = 10;
    [SerializeField] Camera mainCamera;
    [SerializeField] float boomTime;
    Vector3 target;

    private void Awake()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }
    private IEnumerator Start()
    {
        target = new Vector3(10, 0, 0);
        yield return new WaitForSeconds(boomTime);
        Vector3 offset = player.transform.position - transform.position;
        transform.rotation = Quaternion.Euler(new Vector3(0,Mathf.Rad2Deg * Mathf.Atan2(offset.x, offset.z), 0));
        rb.AddForce(-rb.velocity);
    }
    private void Update()
    {
        rb.AddForce(transform.forward * goSpeed); // * Time.deltaTime;
    }
}
