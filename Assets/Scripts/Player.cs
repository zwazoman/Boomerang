using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    protected float speed;
    [SerializeField]
    internal Vector2 InputValue;
    [SerializeField]
    internal Vector2 _context;
    [SerializeField]
    public PlayerBoomerang boomerangManager;
    public GameObject InputPlayerGameObjectClone;

    private void Start()
    {
        Cursor.visible = false; //Afin de cacher le curseur sur pc
        Cursor.lockState = CursorLockMode.Locked; //Optionnel, bloque la souris au millieu de l'écran
        InputPlayerGameObjectClone = FindAnyObjectByType<PlayerInput>().gameObject;
    }
    private void Update()
    {
        OnMove(); //Appelle à chaque frame la fct Update
    }


    public void OnMove() //Gère les contrôles du stick droit
    {
        Vector3 mouvement = new Vector3(InputValue.x, 0, InputValue.y);
        mouvement.Normalize();
        transform.position = transform.position + (speed * mouvement * Time.deltaTime);//transform.position car il faut que les contrôles soit basé sur le world Space
    }

    public void Rotation()//Gère les contrôles du stick gauche
    {
        Vector2 input = _context;
        input.Normalize();
        if (input == new Vector2(0, 0))
        {
            return;
        }
        float rotation = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0f, rotation, 0f);
        transform.rotation = targetRotation;
    }
    private void OnDisable()
    {
        Destroy(InputPlayerGameObjectClone);
    }
}
