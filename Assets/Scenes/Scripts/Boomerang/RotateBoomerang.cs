using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBoomerang : MonoBehaviour
{
    public float rotationPower;
    public GameObject boomerang;
    BoomerangBehaviour boomScript;

    private void Awake()
    {
        boomScript = boomerang.GetComponent<BoomerangBehaviour>();
    }
    void Update()
    {
        if (!boomScript.isFalling) 
        {
            // vérifie si le boomerang tombe
            transform.Rotate(Vector3.forward * rotationPower * Time.deltaTime, Space.Self); // si le boomerang n'est pas entrain de tomberfait tourner le boomerang 
        }
    }
}
