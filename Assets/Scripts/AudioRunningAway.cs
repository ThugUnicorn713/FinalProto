using UnityEngine;

public class AudioRunningAway : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject howlingObject;
    public GameObject runTrigger;

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
                StartCoroutine(DisableAfterAudio());

            }
            
        }
    }

    private System.Collections.IEnumerator DisableAfterAudio()
    {
        yield return new WaitForSeconds(audioSource.clip.length);
        runTrigger.SetActive(false);
    }
}

