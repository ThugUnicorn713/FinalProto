using TMPro;
using UnityEngine;

public class TransformToLycanScript : MonoBehaviour
{
    public TextMeshProUGUI killTurning;
    public AudioPlayer audioPlayer;
    public TextMeshProUGUI killText;
    public TextMeshProUGUI findHim;

    public PlayerLoco playerLoco;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (killTurning != null) 
            {
                killTurning.gameObject.SetActive(true);
                Invoke(nameof(PlayGrowl), 3f);
            }

            findHim.gameObject.SetActive(false);
            killText.gameObject.SetActive(true);
            playerLoco.transformState = AnimalState.Lycan;
            Debug.Log("You are now a Lycan");
        }
    }

    public void PlayGrowl()
    {
        audioPlayer.PlayBigGrowlAudio();
        killTurning.gameObject.SetActive(false);
    }    
        
}
