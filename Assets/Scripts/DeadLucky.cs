using TMPro;
using UnityEngine;

public class DeadLucky : MonoBehaviour
{
    public TextMeshProUGUI deadText;
    public Collider luckyCollider;

    void OnTriggerEnter(Collider other)
    {
        if (deadText != null && other.CompareTag("Player"))
        {
            deadText.gameObject.SetActive(true);
            luckyCollider.enabled = false;   
        }
    }

    
}
