using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPotion : MonoBehaviour
{       
    public GameObject PickUpText;
    public GameObject HealthPotionOnPlayer;
    // Start is called before the first frame update
    void Start()
    {    
        HealthPotionOnPlayer.SetActive(false);
        PickUpText.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        PickUpText.SetActive(true);
        if(other.gameObject.tag == "Player")
        {
            if(Input.GetKey(KeyCode.E))
            {
                this.gameObject.SetActive(false);
                HealthPotionOnPlayer.SetActive(true);
                PickUpText.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PickUpText.SetActive(false);
    }
    
}
