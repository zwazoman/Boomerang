using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    protected float speed;
    [SerializeField]
    internal Vector2 InputValue;
    [SerializeField]
    internal Vector2 _context;

    private void Start()
    {
        Cursor.visible = false; //Afin de cacher le curseur sur pc
        Cursor.lockState = CursorLockMode.Locked; //Optionnel, bloque la souris au millieu de l'�cran
    }
    private void Update()
    {
        OnMove(); //Appelle � chaque frame la fct Update
    }


    public void OnMove() //G�re les contr�les du stick droit
    {
        Vector3 mouvement = new Vector3(InputValue.x, 0, InputValue.y);
        mouvement.Normalize();
        transform.position = transform.position + (speed * mouvement * Time.deltaTime);//transform.position car il faut que les contr�les soit bas� sur le world Space
    }

    public void Rotation()//G�re les contr�les du stick gauche
    {
        Vector2 input = _context;
        float rotation = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0f, rotation, 0f);
        transform.rotation = targetRotation;
    }
}
