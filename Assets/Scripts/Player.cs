using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    protected float speed;
    [SerializeField]
    internal Vector2 InputValue;
    [SerializeField]
    protected Vector2 Input_Value_Rotation;
    [SerializeField]
    protected float sensibility = 20f;
    [SerializeField]
    internal Vector2 _context;
    private void Update()
    {
        OnMove();
    }

    public void OnMove()
    {
        Vector3 mouvement = new Vector3(InputValue.x, 0, InputValue.y);
        Debug.Log(mouvement);
        mouvement.Normalize();
        transform.Translate(speed * mouvement * Time.deltaTime);
        Debug.Log(mouvement);
    }

    public void Rotation()
    {
        Vector2 input = _context;
        float rotation = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0f, rotation, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, sensibility * Time.deltaTime);
    }
}
