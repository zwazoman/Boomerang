using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject text1;
    [SerializeField] private GameObject text2;
    [SerializeField] private GameObject text3;
    [SerializeField] private GameObject text4;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioSource source2;
    [SerializeField] private PlayerInput _playerInput;

    public void Awake()
    {
        //GetComponent<PlayerInputManager>().joiningEnabled = true;
        StartCoroutine(_timer());
    }

    IEnumerator _timer()
    {
        yield return new WaitForSeconds(1);
        source.Play();
        text1.SetActive(true);
        yield return new WaitForSeconds(1);
        text1.SetActive(false);
        source.Play();
        text2.SetActive(true);
        yield return new WaitForSeconds(1);
        text2.SetActive(false);
        source.Play();
        text3.SetActive(true);
        yield return new WaitForSeconds(1);
        text3.SetActive(false);
        source2.Play();
        text4.SetActive(true);
        yield return new WaitForSeconds(1);
        text4.SetActive(false);
        _playerInput.SwitchCurrentActionMap("Player");
    }
}
