using TMPro;
using UnityEngine;

public class GroundBuss : MonoBehaviour
{
    public TextMeshProUGUI gunBurn2;

    void OnTriggerEnter(Collider other)
    {
        if (gunBurn2 != null && other.CompareTag("Player"))
        {
            gunBurn2.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && gunBurn2 != null)
        {
            gunBurn2.gameObject.SetActive(false);
        }
    }
}
