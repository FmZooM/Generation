using UnityEngine;


public class PlaySoundOnClick : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip soundClip;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) // Клавиша R
        {
            audioSource.PlayOneShot(soundClip);
        }
    }
}
