using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveController
{
    private const string LevelsOpened = "LevelsOpened";
    static SaveController()
    {
        if (!PlayerPrefs.HasKey(LevelsOpened))
        {
            PlayerPrefs.SetInt(LevelsOpened, 1);
        }
    }
    public static void PlayingForFirstTime()
    {
        PlayerPrefs.SetInt(LevelsOpened, 1);
    }
    public static int GetInt(string key)
    {
        return PlayerPrefs.GetInt(LevelsOpened);
    }
    public static void SetInt(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }
}
