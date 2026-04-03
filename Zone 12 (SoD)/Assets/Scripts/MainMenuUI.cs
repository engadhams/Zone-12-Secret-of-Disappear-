using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public bool canPause=true;
    public GameObject pauseM;
    void Start()
    {
        if(canPause)
            pauseM.SetActive(false);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && canPause)
        {
            pauseGame();
        }
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Loading");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void pauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        pauseM.SetActive(true);
        Time.timeScale = 0f;
    }
    public void resumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pauseM.SetActive(false);
        Time.timeScale = 1f;
    }
    public void GoToMM()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
