using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSwitchController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> levelButtons = new();

    private void Start()
    {
        for (int i = 0 ; i < SaveController.GetInt("LevelsOpened"); i++)
        {
            Color tmp = levelButtons[i].GetComponent<RawImage>().color;
            tmp.a = 1f;
            levelButtons[i].GetComponent<RawImage>().color = tmp;
            levelButtons[i].GetComponent<Button>().enabled = true;
        }
    }

    public void PlayLevel(int level)
    {
        SceneManager.LoadScene(level + 1);
    }
}
