using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    SoundManager soundManager;
    public static bool isGamePaused = false;
    private void Start()
    {
        pauseMenu.SetActive(false);
        soundManager = SoundManager.instance;
        if (!soundManager)
        {
            Debug.LogError("Soundmanager not found");
        }
    }
    public void Pause()
    {
        if (soundManager)
        {
            soundManager.PlaySfx(Sounds.GameOver);
        }
        isGamePaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }public void Resume()
    {
        if (soundManager)
        {
            soundManager.PlaySfx(Sounds.GameOver);
        }
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    
}
