using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private GameObject WinImage;

    [SerializeField]
    private GameObject LoseImage;

    public void AnnounceWin()
    {
        WinImage.SetActive(true);
    }

    public void AnnounceLose()
    {
        LoseImage.SetActive(true);
    }

    public void NextLevel()
    {
        if(SceneManager.sceneCountInBuildSettings > SceneManager.GetActiveScene().buildIndex + 1)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
            SceneManager.LoadScene(0);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Continue()
    {
        SceneManager.LoadScene(2);
    }
    public void LevelSwitchMenu()
    {
       SceneManager.LoadScene(1);
    }
}
