using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPotionGuardian : MonoBehaviour
{
    public GameObject DropPotionText;
    public GameObject HealthPotionOnPlayer;
    public GameObject BoneOnPlayer;
    public GameObject HealthPotionOnGuardian;
    // Start is called before the first frame update
    void Start()
    {
        HealthPotionOnGuardian.SetActive(false);
        BoneOnPlayer.SetActive(false);
        DropPotionText.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
       // if(HealthPotionOnPlayer.gameObject.Active(true))
       // {
            
            if(other.gameObject.tag == "Player")
            {
            DropPotionText.SetActive(true);
            if(Input.GetKey(KeyCode.Q))
            {
                HealthPotionOnGuardian.SetActive(true);
                HealthPotionOnPlayer.SetActive(false);
                DropPotionText.SetActive(false);
                BoneOnPlayer.SetActive(true);
            }
            }
       // }
        
    }

     private void OnTriggerExit(Collider other)
    {
        DropPotionText.SetActive(false);
    }
    
}
