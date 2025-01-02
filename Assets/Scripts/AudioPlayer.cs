using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public static bool isWalking = false;

    public AudioSource audioSource;
    public AudioSource audioSource2;
    public AudioSource audioSource3;

    public AudioClip footstepsStart;
    public AudioClip halfFootstep;
    public AudioClip halfBreathing;

    public PlayerLoco playerLoco;

    private float lastHalfFootstepTime = 0f;
    public float halfFootstepCooldown = 0.5f;


    void Start()
    {
        if (audioSource == null || audioSource2 == null || audioSource3 == null)
        {
            Debug.LogError("AudioSources are not properly assigned.");
        }
    }


    void Update()
    {
        //Debug.Log($"AudioPlayer - isWalking: {isWalking}, transformState: {playerLoco.transformState}");

        switch (playerLoco.transformState)
        {
            case AnimalState.Human:
                if (isWalking)
                {
                    FootstepsAudio();
                }
                else
                {
                    StopFootstepsAudio();
                }
                break;

            case AnimalState.Half:
                
                Debug.Log("Audio detects Half state!");
                audioSource.Stop();
                BreathingAudio();

                if (isWalking)
                {
                    HalfFootstepsAudio();
                }
                else
                {
                    Debug.Log("Footsteps stopped");
                    StopHalfFootstepsAudio();
                }
                break;

            default:
               // StopAllFootstepsAudio(); // Stop all audio if no relevant state
                break;
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

    public void HalfFootstepsAudio()
    {

        if (!audioSource2.isPlaying && isWalking && Time.time - lastHalfFootstepTime >= halfFootstepCooldown)
        {
            Debug.Log("Playing half footstep audio");
            audioSource2.PlayOneShot(halfFootstep);
            lastHalfFootstepTime = Time.time;
        }
        Debug.Log($"HalfFootstepsAudio - isWalking: {isWalking}, audioSource2.isPlaying: {audioSource2.isPlaying}");
    }

    public void StopHalfFootstepsAudio()
    {
        if (audioSource2.isPlaying && !isWalking)
        {
            audioSource2.Stop();
        }

        //Debug.Log($"StopHalfFootstepsAudio - isWalking: {isWalking}, audioSource2.isPlaying: {audioSource2.isPlaying}");
    }

    public void BreathingAudio()
    {
        if (!audioSource3.isPlaying)
        {
            audioSource3.PlayOneShot(halfBreathing);
        }
    }

    public void StopBreathingAudio()
    {
        if (audioSource3.isPlaying)
        {
            audioSource.Stop();
        }
    }

    public void StopAllFootstepsAudio()
    {
        StopFootstepsAudio();
        StopHalfFootstepsAudio();
    }

}
