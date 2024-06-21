    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class PickUpBone : MonoBehaviour
    {
        public GameObject PickUpBoneText;
        public GameObject BoneOnPlayer;
        // Start is called before the first frame update
        void Start()
        {
            BoneOnPlayer.SetActive(false);
            PickUpBoneText.SetActive(false);
        }

        private void OnTriggerStay(Collider other)
        {
            PickUpBoneText.SetActive(true);
            if (other.gameObject.tag == "Player")
            {
                if (Input.GetKey(KeyCode.E))
                {
                    this.gameObject.SetActive(false);
                    BoneOnPlayer.SetActive(true);
                    PickUpBoneText.SetActive(false);
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            PickUpBoneText.SetActive(false);
        }

}

