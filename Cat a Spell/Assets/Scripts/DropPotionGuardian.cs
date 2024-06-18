using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPotionGuardian : MonoBehaviour
{
    public GameObject DropPotionText;
    public GameObject OutOfPotionText;
    public GameObject HealthPotionOnPlayer;
    public GameObject BoneOnPlayer;
    public GameObject HealthPotionOnGuardian;
    // Start is called before the first frame update
    void Start()
    {
        HealthPotionOnGuardian.SetActive(false);
        BoneOnPlayer.SetActive(false);
        DropPotionText.SetActive(false);
        OutOfPotionText.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    { 
            if(other.gameObject.tag == "Player")
            {
            
            if(HealthPotionOnPlayer.activeSelf == true)
            {
            DropPotionText.SetActive(true);
            if(Input.GetKey(KeyCode.Q))
            {
                HealthPotionOnGuardian.SetActive(true);
                HealthPotionOnPlayer.SetActive(false);
                DropPotionText.SetActive(false);
                BoneOnPlayer.SetActive(true);
            }
            }else
            {
                OutOfPotionText.SetActive(true);
            }
        } 
        
    }

     private void OnTriggerExit(Collider other)
    {
        DropPotionText.SetActive(false);
        OutOfPotionText.SetActive(false);
    }
    
}
