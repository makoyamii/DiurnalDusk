using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioClip click;

    public void Play() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        soudns.instance.PlaySound(click);
    }

    public void Quit() {
        print("quitting game");
        Application.Quit();
        soudns.instance.PlaySound(click);
    }
}
