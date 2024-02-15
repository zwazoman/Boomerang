using System.Collections;
using System.Collections.Generic;
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


    private void Start()
    {
        Debug.Log("player spawn");
        Cursor.visible = false; //Afin de cacher le curseur sur pc
        Cursor.lockState = CursorLockMode.Locked; //Optionnel, bloque la souris au millieu de l'écran
        Debug.Log(objectWithList.GetComponent<joinDuringGame>().playerWithController.Count);
        InputPlayerGameObjectClone = objectWithList.GetComponent<joinDuringGame>().InputPlayerList[FindIndiceOfObjectInList(objectWithList.GetComponent<joinDuringGame>().playerWithController, gameObject)];
    }
    private void Update()
    {
        Debug.Log((objectWithList.GetComponent<joinDuringGame>().playerWithController.Count, "from script Player"));
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
        objectWithList.GetComponent<joinDuringGame>().InputPlayerList.Remove(InputPlayerGameObjectClone);
        Destroy(InputPlayerGameObjectClone);
    }

    public int FindIndiceOfObjectInList(List<GameObject> _TargetList, GameObject _objectWeWantIndice)
    {
        Debug.Log("start loop to find object indice");
        Debug.Log(_TargetList.Count);
        int compteur = 0;
        foreach (GameObject obj in _TargetList)
        {
            compteur++;
            Debug.Log(("Target object name", _objectWeWantIndice.transform.name));
            if (obj.transform.name == _objectWeWantIndice.transform.name)
            {
                print(compteur);
                Debug.Log(("", obj.transform.name));
                return compteur;
            }
        }
        Debug.LogError("Error 404");
        return compteur;
    }
}
