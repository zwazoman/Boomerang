using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayers : MonoBehaviour
{
    [SerializeField]
    float rotationSpeed;
    private void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
