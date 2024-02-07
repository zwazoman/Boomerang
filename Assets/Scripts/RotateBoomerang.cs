using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBoomerang : MonoBehaviour
{
    public float rotationPower;
    void Update()
    {
        if (!IsGrounded())
        {
        transform.Rotate(Vector3.forward * rotationPower * Time.deltaTime, Space.Self);
        }


    }
    bool IsGrounded()
    {
        if (transform.parent.position.y <= 1)
        {
            return true;
        }
        return false;
    }

    void BoomerangTouched()
    {

    }
}
