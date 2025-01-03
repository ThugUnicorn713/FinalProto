using System.Collections;
using TMPro;
using UnityEngine;

public class GunBounds : MonoBehaviour
{
    public TextMeshProUGUI notStupidText;
    public Rigidbody playerRB;

    void OnCollisionEnter(Collision collision)
    {
        if (notStupidText != null && collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(FreezePlayer());
        }
    }

    private IEnumerator FreezePlayer()
    {
        playerRB.constraints = RigidbodyConstraints.FreezeAll;
        notStupidText.gameObject.SetActive(true);

        yield return new WaitForSeconds(3f);

        playerRB.constraints = RigidbodyConstraints.FreezeRotation;
        notStupidText.gameObject.SetActive(false);
    }
}
