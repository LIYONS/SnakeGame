using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    SoundManager soundManager;
    private void Start()
    {
        soundManager = SoundManager.instance;
        if(! soundManager)
        {
            Debug.LogError("Soundmanager not found");
        }
    }
    public void LoadLevel(int buildIndex)
    {
        if(soundManager)
        {
            soundManager.PlaySfx(Sounds.ButtonClick);
            soundManager.ResetSounds();
        }
        if (PauseMenu.isGamePaused)
        {
            Time.timeScale = 1f;
        }
        SceneManager.LoadScene(buildIndex);
    }
    public void Restart()
    {
        if (soundManager)
        {
            soundManager.PlaySfx(Sounds.ButtonClick);
            soundManager.ResetSounds();
        }
        if (PauseMenu.isGamePaused)
        {
            Time.timeScale = 1f;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        if (soundManager)
        {
            soundManager.PlaySfx(Sounds.ButtonClick);
        }
        if (PauseMenu.isGamePaused)
        {
            Time.timeScale = 1f;
        }
        Application.Quit();
    }
}
