using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPhaseBones : MonoBehaviour
{
    public PlayerController player;
    public GameObject Fire;
    public GameObject Skull;
    public GameObject BoneOnPlayer;
    public GameObject DropBonesText;
    public GameObject LevelCompleteText;
    public GameObject RestartLevelButton;
    public GameObject RestartGameButton;
    public string nextLevel;
    // Start is called before the first frame update
    void Start()
    {
        Fire.SetActive(false);
        Skull.SetActive(false);
        DropBonesText.SetActive(false);
        LevelCompleteText.SetActive(false);
        RestartGameButton.SetActive(false);
        RestartLevelButton.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
            
            if(other.gameObject.tag == "Player")
            {
            DropBonesText.SetActive(true);
            if(Input.GetKey(KeyCode.Q))
            {
                Fire.SetActive(true);
                Skull.SetActive(true);
                BoneOnPlayer.SetActive(false);
                DropBonesText.SetActive(false);
            }

            if(Fire.activeSelf == true && Skull.activeSelf == true){
                DropBonesText.SetActive(false);

                LevelCompleteText.SetActive(true);
                RestartLevelButton.SetActive(true);
                RestartGameButton.SetActive(true);
                player.moveSpeed = 0f;
            }
            }
        
    }

     private void OnTriggerExit(Collider other)
    {
        DropBonesText.SetActive(false);
    }

    public void ResetTheLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        print("Ta funcionando.");
    }

    public void ResetTheGame(){
        
        if(nextLevel != ""){
            SceneManager.LoadScene(nextLevel);
        }
    }
    
}
