using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashManager : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    float dashForce;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    internal void Dash()
    {
        rb.AddForce(transform.forward * dashForce,ForceMode.Impulse);
    }
}
