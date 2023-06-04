using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text whoWonText;
    [SerializeField] List<PlayerController> playerControllers;
    [SerializeField] GameObject winScreen;


    private void Start()
    {
        Time.timeScale = 1.0f;
        playerControllers.AddRange(GameObject.FindObjectsOfType<PlayerController>());
    }

    private void Update()
    {
        for (int i = 0; i < playerControllers.Count; i++) {
            if (playerControllers[i].health == 0) {
                playerControllers[i].gameObject.SetActive(false);
                playerControllers.RemoveAt(i);
            }
        }

        if(playerControllers.Count == 1) {
            
            Time.timeScale = 0.3f;
            winScreen.SetActive(true);
            whoWonText.text = playerControllers[0].name + " wins!";
        }
    }


    public void RestartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitButton()
    {
        SceneManager.LoadScene(0);
    }
}
