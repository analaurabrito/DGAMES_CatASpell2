using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSword : MonoBehaviour
{
    public GameObject PickUpText;
    public GameObject SwordOnPlayer;

    // Start is called before the first frame update
    void Start()
    {
        SwordOnPlayer.SetActive(false);
        PickUpText.SetActive(false);
    }

    public void OnTriggerStay(Collider other)
    {
        PickUpText.SetActive(true);
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                this.gameObject.SetActive(false);
                SwordOnPlayer.SetActive(true);
                PickUpText.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PickUpText.SetActive(false);
    }
}
