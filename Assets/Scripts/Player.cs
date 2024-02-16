using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public PlayerBoomerang boomerangManager;
    public GameObject InputPlayerGameObjectClone;
    public GameObject objectWithList;
    public bool isFirstTimeEnable = true;
    public Animator animator;


    private void Start()
    {
        if (isFirstTimeEnable)
        {
            Initialize();
        }
        isFirstTimeEnable = false;
    }

    private void OnEnable()
    {
        if (!isFirstTimeEnable)
        {
            Initialize();
        }
    }

    private void Initialize()
    {
        Cursor.visible = false; //Afin de cacher le curseur sur pc
        Cursor.lockState = CursorLockMode.Locked; //Optionnel, bloque la souris au millieu de l'écran
        int objectIndexInLIst = objectWithList.GetComponent<joinDuringGame>().playerWithController.IndexOf(gameObject);
        Debug.Log(objectIndexInLIst);

        if (objectIndexInLIst == -1)
        {
            Debug.LogError("PROBLEM");
        }
        else
        {
            InputPlayerGameObjectClone = objectWithList.GetComponent<joinDuringGame>().InputPlayerList[objectIndexInLIst];
        }
    }

    /* 
     Explication de notre plus gros problème :
        Pour faire simple, lorsqu'un gameObject de joueur est appelé pour la deuxième (setActiveTrue) un probleme se crée à la ligne 52 qui nous dit que 
        l'indexe auquel on essaye d'accéder dans la liste est en dehors de la liste en question, alors que dans l'inspecteur on peut voir que l'indice 
        est valide, le scripts qui possède la liste nous dis la même chose, mais IMPOSSIBLE de trouver pourquoi ça fait ça...
     */

    private void Update()
    {
        OnMove(); //Appelle à chaque frame la fct Update
    }


    public void OnMove() //Gère les contrôles du stick droit
    {
        Vector3 mouvement = new Vector3(InputValue.x, 0, InputValue.y);
        mouvement.Normalize();
        transform.position = transform.position + (speed * mouvement * Time.deltaTime);// transform.position car il faut que les contrôles soit basé sur le world Space
        animator.SetFloat("AxisUp", mouvement.magnitude);
        animator.SetFloat("AxisLow", mouvement.magnitude);
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
        this.objectWithList.GetComponent<joinDuringGame>().InputPlayerList.Remove(this.InputPlayerGameObjectClone);
        Destroy(this.InputPlayerGameObjectClone);
    }
}
