using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    
    public TextMeshProUGUI wheresLucky;
    public TextMeshProUGUI deadLucky;
    public TextMeshProUGUI gonnaFind;
    public TextMeshProUGUI gonnaKill;
    public TextMeshProUGUI followHowl;
    public TextMeshProUGUI luckyAgain;
    public TextMeshProUGUI gunBurn;
    public TextMeshProUGUI findHim;
    public TextMeshProUGUI myHead;



    public GameObject takeGunPanel;
    public GameObject basicMove;
    public GameObject halfMove;
    public GameObject luckyBounds;
    public GameObject gunBounds;
    public GameObject houseBlunder;
    public GameObject playerBlunder;
    public GameObject doorTrigger;
    public GameObject playerBlunderBuss;
    public GameObject groundBlunderBuss;

    public Collider houseBlunderCollider;
    

    void Start()
    {
        wheresLucky.gameObject.SetActive(true);  
        basicMove.SetActive(true);
        houseBlunderCollider.enabled = false;
        Invoke(nameof(TurnOffFirstText), 5f);
        Invoke(nameof(TurnOffBasicMove), 10f);
    }

    void Update()
    {
        if(deadLucky != null && deadLucky.isActiveAndEnabled)
        {
            Debug.Log("Lucky is now dead");
            Invoke(nameof(ShowGonnaFindText), 3f);
            Invoke(nameof(TurnOffGonnaFindText), 5f);
        }

        if (myHead != null && myHead.isActiveAndEnabled)
        {
            Invoke(nameof(DropGun), 5f);
        }


        if (gunBurn != null && gunBurn.isActiveAndEnabled)
        {
            Invoke(nameof(Stage2), 5f);
        }
    }

    public void TurnOffFirstText()
    {
        wheresLucky.gameObject.SetActive(false);
    }

    public void ShowGonnaFindText()
    {
        deadLucky.gameObject.SetActive(false);
        gonnaFind.gameObject.SetActive(true);
        luckyBounds.SetActive(false);
        gunBounds.SetActive(true);
        doorTrigger.SetActive(false);
        houseBlunderCollider.enabled = true;
    }

    public void TurnOffGonnaFindText()
    {
        gonnaFind.gameObject.SetActive(false);
    }

    public void Stage2() 
    {
        gunBurn.gameObject.SetActive(false);
        gonnaKill.gameObject.SetActive(true);
        halfMove.SetActive(true);
        followHowl.gameObject.SetActive(false);
        findHim.gameObject.SetActive(true);
        Invoke(nameof(TurnOffStage2), 5f);
    }

    public void TurnOffStage2()
    {
        gonnaKill.gameObject.SetActive(false);
        halfMove.SetActive(false);
    }

    public void DropGun()
    {
        myHead.gameObject.SetActive(false);
        playerBlunderBuss.SetActive(false);
        groundBlunderBuss.SetActive(true);
        gunBurn.gameObject.SetActive(true);

    }

    public void TakeButton()
    {
        if(takeGunPanel != null)
        {
            houseBlunder.SetActive(false);
            playerBlunder.SetActive(true);
            takeGunPanel.SetActive(false);
            followHowl.gameObject.SetActive(true);
            gunBounds.SetActive(false);

        }
    }
    public void TurnOffBasicMove()
    {
        basicMove.gameObject.SetActive(false);
    }
}
