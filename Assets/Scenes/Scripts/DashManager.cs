using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashManager : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    float dashForce;
    internal Vector2 InputValue;
    bool canDash = true;
    [SerializeField]
    float timeBetweenDashes;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    internal IEnumerator Dash()
    {
        print("essaie de dash");
        if (canDash)
        {
            print("dash");
            Vector3 mouvement = new Vector3(InputValue.x, 0, InputValue.y);
            if(mouvement == Vector3.zero)
            {
                rb.AddForce(transform.forward, ForceMode.Impulse);
            }
            rb.AddForce(mouvement * dashForce, ForceMode.Impulse);
            canDash = false;
            yield return new WaitForSeconds(timeBetweenDashes);
            canDash = true;
        }
    }
}
