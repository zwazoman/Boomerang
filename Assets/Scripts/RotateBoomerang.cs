using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBoomerang : MonoBehaviour
{
    public float rotationPower;
    public testBoomerang test;
    bool isGrounded;
    private void Awake()
    {
        isGrounded = transform.parent.GetComponent<testBoomerang>().IsGrounded();
    }
    void Update()
    {
        if (!isGrounded)
        {
        transform.Rotate(Vector3.forward * rotationPower * Time.deltaTime, Space.Self);
        }
    }
}
