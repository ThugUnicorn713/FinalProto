using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public static bool isWalking = false;

    public AudioSource audioSource;
    public AudioClip footstepsStart;




    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    void Update()
    {
        if (isWalking)
        {
            FootstepsAudio();
        }
        else
        {
            StopFootstepsAudio();
            isWalking = false;
        }
    }

    public void FootstepsAudio()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(footstepsStart);
        }

    }

    public void StopFootstepsAudio()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }

    }

}
