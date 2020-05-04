using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIElements : MonoBehaviour
{
    public static bool isGamePause = false;
    public GameObject pauseMenuUI, fpsPlayer, gun;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (isGamePause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    //Scripts for button related functions
    public void RestartMap()
    {
        isGamePause = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void backtoMainMenu()
    {
        if (isGamePause)
        {
            Time.timeScale = 1;
        }
        SceneManager.LoadScene("MainMenu");
    }



    public void QuitGame()
    {
        Application.Quit();
    }

    public void Resume()
    {
        fpsPlayer.GetComponent<PlayerControl>().enabled = true;
        gun.GetComponent<Gun>().enabled = true;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        isGamePause = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Pause()
    {
        Time.timeScale = 0;
        isGamePause = true;
        fpsPlayer.GetComponent<PlayerControl>().enabled = false;
        gun.GetComponent<Gun>().enabled = false;
        pauseMenuUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
}
