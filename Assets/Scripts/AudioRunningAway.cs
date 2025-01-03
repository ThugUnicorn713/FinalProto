using UnityEngine;

public class AudioRunningAway : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject howlingObject;
    public GameObject runTrigger;
    public Rigidbody playerRB;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (audioSource != null)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                howlingObject.SetActive(false);
                audioSource.Play();
                playerRB.constraints = RigidbodyConstraints.FreezeAll;
                StartCoroutine(DisableAfterAudio());
                
            }
            
        }
    }

    private System.Collections.IEnumerator DisableAfterAudio()
    {
        yield return new WaitForSeconds(audioSource.clip.length);
        runTrigger.SetActive(false);
        playerRB.constraints = RigidbodyConstraints.FreezeRotation;
    }
}

