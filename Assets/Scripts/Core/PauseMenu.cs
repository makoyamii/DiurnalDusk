using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public AudioClip click;
    public GameObject pauseMenu;
    public static bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X)) {
            if(isPaused) {
                ResumeGame();
            } else {
                PauseGame();
            }
        }
        
    }

    public void PauseGame() {
        soudns.instance.PlaySound(click);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame() {
        soudns.instance.PlaySound(click);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void GoToMainMenu() {
        soudns.instance.PlaySound(click);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

    public void Restart() {
        soudns.instance.PlaySound(click);
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Forest")) {
            SceneManager.LoadScene("Forest");
            Time.timeScale = 1f;
        } else if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Night")) {
            SceneManager.LoadScene("Night");
            Time.timeScale = 1f;
        } else if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Beginning")) {
            SceneManager.LoadScene("Beginning");
            Time.timeScale = 1f;
        }
        
    }

    public void SkipToNight() {
        soudns.instance.PlaySound(click);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Night");
    }

    public void BackToDay() {
        soudns.instance.PlaySound(click);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Forest");
    }
}
