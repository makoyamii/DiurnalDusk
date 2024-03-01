using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimeUI : MonoBehaviour
{
    
    public Text timeText;

    private void OnEnable() {
        Timer.OnMinuteChanged += UpdateTime;
        Timer.OnHourChanged += UpdateTime;
    }

    private void OnDisable() {
        Timer.OnMinuteChanged -= UpdateTime;
        Timer.OnHourChanged -= UpdateTime;
    }

    private void UpdateTime() {
        timeText.text = $"{Timer.Hour:00}:{Timer.Minute:00}";

    }
    
}
