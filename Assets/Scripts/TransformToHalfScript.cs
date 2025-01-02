using UnityEngine;

public class TransformToHalfScript : MonoBehaviour
{
    public PlayerLoco playerLoco;
    public GameObject deadAnimal2;
    public GameObject transformTrigger;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerLoco.transformState = AnimalState.Half;
            Debug.Log("You are now a Half");
            transformTrigger.SetActive(false);
            deadAnimal2.SetActive(true);
        }
    }
}
