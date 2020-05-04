using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject quitGameDialogBox, mainMenuPanel, mapSelectPanel;
   public void playGame()
    {
        mapSelectPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }

    public void optionMenu()
    {
        Debug.Log("Load Options Panel");
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void showquitGameDialogBox()
    {
        quitGameDialogBox.SetActive(true);
    }

    public void showMainMenu()
    {
        quitGameDialogBox.SetActive(false);
        mainMenuPanel.SetActive(true);        
    }

    public void backtoMainMenu()
    {
        mapSelectPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void loadMap1()
    {
        SceneManager.LoadScene("Map1");
    }
}
