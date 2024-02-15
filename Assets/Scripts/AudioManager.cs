using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance = null;

    public static AudioManager Instance => _instance;

    [SerializeField] AudioClip throwSound;
    [SerializeField] AudioClip dieSound;
    [SerializeField] AudioClip catchSound;
    [SerializeField] AudioClip walkSound;
    [SerializeField] AudioClip winSound;
    [SerializeField] AudioClip buttonClickSound;

    private void Awake()
    {
        // Singleton
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            _instance = this;
            this.transform.SetParent(null);
            DontDestroyOnLoad(this);
        }
    }

    internal void PlayThrow()
    {
        PlaySound(throwSound); // pitch random entre 0.8 et 1
    }

    internal void PlayDie()
    {
        PlaySound(dieSound);
    }

    void PlaySound(AudioClip clip, float _pitch = 1, float _volume = 1)
    {
        AudioSource source = gameObject.AddComponent<AudioSource>();
        source.volume = _volume;
        source.pitch = _pitch;
        source.PlayOneShot(clip);
        Destroy(source, 3);
    }
}
