using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance = null;

    public static AudioManager Instance => _instance;

    [SerializeField] AudioClip throwSound;
    [SerializeField] AudioClip dieSound;
    [SerializeField] AudioClip catchSound;
    [SerializeField] AudioClip winSound;

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
        PlaySound(throwSound,Random.Range(0.6f,0.8f),0.8f); // pitch random entre 0.8 et 1
    }

    internal void PlayDie()
    {
        PlaySound(dieSound);
    }

    internal void PlayCatch()
    {
        PlaySound(catchSound, Random.Range(0.8f,1));
    }

    internal void PlayWin()
    {
        PlaySound(winSound);
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
