using System.Collections;
using UnityEngine;

public class _Start : MonoBehaviour
{
    private GameObject text1;
    private GameObject text2;
    private GameObject text3;
    private GameObject text4;
    private AudioSource source;
    private AudioSource source2;

    public void Awake()
    {
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
    }
}
