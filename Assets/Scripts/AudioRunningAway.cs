using UnityEngine;

public class AudioRunningAway : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject howlingObject;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (audioSource != null)
        {
            if (other.CompareTag("Player"))
            {
                howlingObject.SetActive(false);
                audioSource.Play();


            }
            
        }
    }
}
