using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DropBone : MonoBehaviour
{
    public PlayerController player;
    public GameObject LevelCompleteText;
    public GameObject NextLevelButton;
    public GameObject RestartLevelButton;
    public GameObject RestartGameButton;
    public GameObject DropText;
    public GameObject BoneOnPlayer;
    public GameObject BoneOnPlatform;

    public string nextLevel;
    // Start is called before the first frame update
    void Start()
    {
        BoneOnPlatform.SetActive(false);
        LevelCompleteText.SetActive(false);
        NextLevelButton.SetActive(false);
        RestartGameButton.SetActive(false);
        RestartLevelButton.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            DropText.SetActive(true);
            if (Input.GetKey(KeyCode.Q))
            {
                BoneOnPlatform.SetActive(true);
                BoneOnPlayer.SetActive(false);
                DropText.SetActive(false);
            }

            if (BoneOnPlatform.activeSelf == true)
            {
                DropText.SetActive(false);

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
        DropText.SetActive(false);
    }

    public void ResetTheLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        print("Ta funcionando.");
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }

    public void FirstLevel()
    {
        SceneManager.LoadScene("level_1");
    }

}
