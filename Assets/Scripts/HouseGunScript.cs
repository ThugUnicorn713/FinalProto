using UnityEngine;

public class HouseGunScript : MonoBehaviour
{
    public GameObject takeGunPanel;

     void OnTriggerEnter(Collider other)
     {
        if (takeGunPanel != null && other.CompareTag("Player"))
        {
            takeGunPanel.SetActive(true);
        }
        
     }
}
