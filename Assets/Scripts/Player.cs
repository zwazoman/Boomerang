using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    public float speed;
    [SerializeField]
    public Vector2 InputValue;



    private void Update()
    {
        Vector3 mouvement = new Vector3(InputValue.x, 0, InputValue.y);
        mouvement.Normalize();
        transform.Translate(speed * mouvement * Time.deltaTime);
    }
}
