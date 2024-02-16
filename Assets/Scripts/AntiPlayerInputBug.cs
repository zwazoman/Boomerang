using UnityEngine;

public class AntiPlayerInputBug : MonoBehaviour
{
    public GameObject objectWithList;
    public bool isAttributeToPLayer;

    // Start is called before the first frame update
    void Awake()
    {
        //objectWithList = FindAnyObjectByType<Player>().GetComponent<Player>().objectWithList;
        objectWithList = FindAnyObjectByType<joinDuringGame>().gameObject;
        objectWithList.GetComponent<joinDuringGame>().InputPlayerList.Add(gameObject);
    }
}
