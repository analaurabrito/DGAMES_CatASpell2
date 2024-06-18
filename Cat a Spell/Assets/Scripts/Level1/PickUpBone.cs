using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBone : MonoBehaviour
{
    public GameObject PickUpText;
    public GameObject BoneOnPlayer;

    // Start is called before the first frame update
    void Start()
    {
        BoneOnPlayer.SetActive(false);
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
                BoneOnPlayer.SetActive(true);
                PickUpText.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PickUpText.SetActive(false);
    }
}
