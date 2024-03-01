using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    public static Action OnMinuteChanged;
    public static Action OnHourChanged;

    public static int Minute { get; private set; }
    public static int Hour { get; private set; }

    private float minuteToRealTime = 0.25f;
    private float timer;


    void Start() {

        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Forest")) {
            Minute = 0;
            Hour = 12;
            timer = minuteToRealTime;
        } else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Night")) {
            Minute = 0;
            Hour = 6;
            timer = minuteToRealTime;
        }
        

    }

    void FixedUpdate() {

        timer -= Time.deltaTime;

        if(timer <= 0) {
            Minute++;
            OnMinuteChanged?.Invoke();
            if(Hour == 5 && Minute == 59 && SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Forest")) {
                SceneManager.LoadScene("Night");
            }

            if(Hour == 11 && Minute == 59 && SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Night")) {
                SceneManager.LoadScene("GameOver");
            }

            if(Minute >= 60) {
                
                if(Hour + 1 <= 12) {
                    Hour++;
                } else {
                    Hour = 1;
                }
                
                Minute = 0;
            }
            timer = minuteToRealTime;
            OnHourChanged?.Invoke();
        }

    }


}
