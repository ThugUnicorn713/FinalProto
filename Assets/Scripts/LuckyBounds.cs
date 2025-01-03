using System.Collections;
using TMPro;
using UnityEngine;

public class LuckyBounds : MonoBehaviour
{
    public TextMeshProUGUI cantWoods;
    public Rigidbody playerRB;

    void OnCollisionEnter(Collision collision)
    {
        if (cantWoods != null && collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(FreezePlayer());
        }
    }

    private IEnumerator FreezePlayer()
    {
        playerRB.constraints = RigidbodyConstraints.FreezeAll;
        cantWoods.gameObject.SetActive(true);

        yield return new WaitForSeconds(3f);

        playerRB.constraints = RigidbodyConstraints.FreezeRotation;
        cantWoods.gameObject.SetActive(false);
    }
}

