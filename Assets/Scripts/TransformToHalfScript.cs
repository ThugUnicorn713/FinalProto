using TMPro;
using UnityEngine;

public class TransformToHalfScript : MonoBehaviour
{
    public PlayerLoco playerLoco;
    public GameObject deadAnimal2;
    public GameObject transformTrigger;
    

    public TextMeshProUGUI luckyAgain;
    public TextMeshProUGUI myHeadText;
    public TextMeshProUGUI gunBurnText;


    public AudioPlayer audioPlayer;

    public Rigidbody playerRB;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (luckyAgain != null)
            {
                luckyAgain.gameObject.SetActive(true);
                Invoke(nameof(PlayGrowl), 5f);
            }

            playerLoco.transformState = AnimalState.Half;
            Debug.Log("You are now a Half");
            deadAnimal2.SetActive(true);
            transformTrigger.SetActive(false);
            
        }
    }

    public void PlayGrowl()
    {
        audioPlayer.PlayBigGrowlAudio();
        luckyAgain.gameObject.SetActive(false);
        myHeadText.gameObject.SetActive(true);
    }

   
}
