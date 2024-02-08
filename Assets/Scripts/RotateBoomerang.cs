using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBoomerang : MonoBehaviour
{
    public float rotationPower;
    public GameObject boomerang;
    void Update()
    {
        if (!IsGrounded())
        {
        transform.Rotate(Vector3.forward * rotationPower * Time.deltaTime, Space.Self);
        }
    }
    public bool IsGrounded()
    {
        if (transform.position.y <= 1) return true;
        return false;
    }
}
