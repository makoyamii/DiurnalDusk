using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{   
    public AudioClip click;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainMenu() {
        Time.timeScale = 1f;
        soudns.instance.PlaySound(click);
        SceneManager.LoadScene("Main Menu");
    }
    public void Quit() {
        Time.timeScale = 1f;
        soudns.instance.PlaySound(click);
        Application.Quit();
    }

    public void RetryDay() {
        Time.timeScale = 1f;
        soudns.instance.PlaySound(click);
        SceneManager.LoadScene("Forest");
        
    }

    public void RetryNight() {
        Time.timeScale = 1f;
        soudns.instance.PlaySound(click);
        SceneManager.LoadScene("Night");
    }
    
}
