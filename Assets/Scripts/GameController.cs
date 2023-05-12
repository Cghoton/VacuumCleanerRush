using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    [SerializeField]
    private UIController uIController;

    [SerializeField]
    private SoundController soundController;

    private bool Crash = false;

    private int goalCounter = 0;
    
    private IEnumerator DelayedLoseAnnounce()
    {
        yield return new WaitForSeconds(2f);
        uIController.AnnounceLose();
    }

    private void LevelCompleted()
    {
        soundController.Pause("LongWuum");
        soundController.Play("Signal");
        SaveController.SetInt("LevelsOpened", SceneManager.GetActiveScene().buildIndex);
        uIController.AnnounceWin();
    }

    public void GoalReached()
    {
        goalCounter++;
        if (goalCounter == 2 && !Crash)
        {
            LevelCompleted();
        }
    }
    public void StartCleanerSound()
    {
        soundController.Play("LongWuum");
    }
    public void Crashed()
    {
        soundController.Play("Explosion");
        soundController.Pause("LongWuum");
        if (!Crash)
        {
            Crash = true;
            StartCoroutine(DelayedLoseAnnounce());
        }
    }
}
