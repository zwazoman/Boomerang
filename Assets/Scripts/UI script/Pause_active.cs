using UnityEngine;

public class Pause_active : MonoBehaviour
{
    public void OnPause_active()
    {
        Time.timeScale = 0;
    }

    public void OnPause_desactive()
    {
        Time.timeScale = 1;
    }
}
