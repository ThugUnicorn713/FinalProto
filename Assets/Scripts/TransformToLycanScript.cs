using UnityEngine;

public class TransformToLycanScript : MonoBehaviour
{
    public PlayerLoco playerLoco;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerLoco.transformState = AnimalState.Lycan;
            Debug.Log("You are now a Lycan");
        }
    }
}
