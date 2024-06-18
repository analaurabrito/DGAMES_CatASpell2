using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public GameObject DropSwordText;
    public GameObject OutOfSwordText;
    public GameObject SwordOnPlayer;
    public GameObject BoneOnPlayer;
    public GameObject SwordOnVillage;
    public GameObject ThanksText;


    void Start()
    {
        SwordOnVillage.SetActive(false);
        BoneOnPlayer.SetActive(false);
        ThanksText.SetActive(false);
        DropSwordText.SetActive(false);
        OutOfSwordText.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            if (SwordOnPlayer.activeSelf == true)
            {
                DropSwordText.SetActive(true);
                OutOfSwordText.SetActive(false);
                if (Input.GetKey(KeyCode.Q))
                {
                    SwordOnVillage.SetActive(true);
                    ThanksText.SetActive(true);
                    SwordOnPlayer.SetActive(false);
                    DropSwordText.SetActive(false);
                    BoneOnPlayer.SetActive(true);
                }
            }
            else
            {
                OutOfSwordText.SetActive(true);
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        DropSwordText.SetActive(false);
        OutOfSwordText.SetActive(false);
        ThanksText.SetActive(false);
    }
}
