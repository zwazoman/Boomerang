using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    protected float speed;
    [SerializeField]
    internal Vector2 InputValue;
    [SerializeField]
    internal Vector2 _context;
    public PlayerBoomerang boomerangManager;
    public GameObject InputPlayerGameObjectClone;
    public GameObject objectWithList;

    private void Start()
    {
        Cursor.visible = false; // Afin de cacher le curseur sur pc
        Cursor.lockState = CursorLockMode.Locked; // Optionnel, bloque la souris au milieu de l'écran
        int objectIndexInLIst = objectWithList.GetComponent<joinDuringGame>().playerWithController.IndexOf(gameObject);
        if (objectIndexInLIst == -1)
        {
            Debug.LogError("PROBLEM");
        }
        else
        {
            InputPlayerGameObjectClone = objectWithList.GetComponent<joinDuringGame>().InputPlayerList[objectIndexInLIst];
        }
    }

    private void Update()
    {
        OnMove(); // Appelle à chaque frame la fct OnMove
    }

    public void OnMove() // Gère les contrôles du stick droit
    {
        Vector3 mouvement = new Vector3(InputValue.x, 0, InputValue.y);
        mouvement.Normalize();
        transform.position = transform.position + (speed * mouvement * Time.deltaTime);// transform.position car il faut que les contrôles soit basé sur le world Space
    }

    public void Rotation()// Gère les contrôles du stick gauche
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
        objectWithList.GetComponent<joinDuringGame>().InputPlayerList.Remove(this.InputPlayerGameObjectClone);
        Destroy(this.InputPlayerGameObjectClone);
    }
}
