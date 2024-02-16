using System.Collections;
using UnityEngine;

public class _Start : MonoBehaviour
{
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;
    public GameObject panel;
    public AudioSource _audio;
    public AudioSource _audio2;

    public void Awake()
    {
        StartCoroutine(_timer());
    }

    IEnumerator _timer()
    {
        yield return new WaitForSeconds(1);
        _audio.Play();
        text1.SetActive(true);
        yield return new WaitForSeconds(1);
        text1.SetActive(false);
        _audio.Play();
        text2.SetActive(true);
        yield return new WaitForSeconds(1);
        text2.SetActive(false);
        _audio.Play();
        text3.SetActive(true);
        yield return new WaitForSeconds(1);
        text3.SetActive(false);
        _audio2.Play();
        text4.SetActive(true);
        yield return new WaitForSeconds(1);
        text4.SetActive(false);
        panel.SetActive(false);
    }
}
