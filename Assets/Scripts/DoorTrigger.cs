using TMPro;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public TextMeshProUGUI doorText;

    void OnTriggerEnter(Collider other)
    {
        if (doorText != null && other.CompareTag("Player"))
        {
            doorText.gameObject.SetActive(true);   
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && doorText != null)
        {
            doorText.gameObject.SetActive(false); 
        }
    }
}
