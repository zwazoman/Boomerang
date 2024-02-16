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
