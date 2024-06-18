using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DropBonePlatform : MonoBehaviour
{
    public PlayerController player;
    public GameObject LevelCompleteText;
    public GameObject NextLevelButton;
    public GameObject RestartLevelButton;
    public GameObject RestartGameButton;
    public GameObject DropBoneText;
    public GameObject BoneOnPlayer;
    public GameObject BoneOnPlatform;
    public string nextLevel;
    // Start is called before the first frame update
    void Start()
    {
        BoneOnPlatform.SetActive(false);
        DropBoneText.SetActive(false);
        LevelCompleteText.SetActive(false);
        NextLevelButton.SetActive(false);
        RestartGameButton.SetActive(false);
        RestartLevelButton.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
            
            if(other.gameObject.tag == "Player")
            {
            DropBoneText.SetActive(true);
            if(Input.GetKey(KeyCode.Q))
            {
                BoneOnPlatform.SetActive(true);
                BoneOnPlayer.SetActive(false);
                DropBoneText.SetActive(false);
            }

            if(BoneOnPlatform.activeSelf == true){
                DropBoneText.SetActive(false);

                LevelCompleteText.SetActive(true);
                NextLevelButton.SetActive(true);
                RestartLevelButton.SetActive(true);
                RestartGameButton.SetActive(true);
                player.moveSpeed = 0f;
            }
            }
        
    }

     private void OnTriggerExit(Collider other)
    {
        DropBoneText.SetActive(false);
    }

    public void ResetTheLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        print("Ta funcionando.");
    }

    public void ResetTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        print("Ta funcionando.");
    }

    public void NextLevel(){
        
        if(nextLevel != ""){
            SceneManager.LoadScene(nextLevel);
        }
    }
    
}
