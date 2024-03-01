using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineShake : MonoBehaviour
{
    public static CinemachineShake Instance {get; private set;} 

    private CinemachineVirtualCamera cam;
    private float shakeTimer;

    void Awake() {
        Instance = this;
        cam = GetComponent<CinemachineVirtualCamera>();
    }

    public void ShakeCamera(float intensity, float time) {
        CinemachineBasicMultiChannelPerlin camperlin = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        camperlin.m_AmplitudeGain = intensity;
        shakeTimer = time;
    }

    private void Update() {
        if(shakeTimer > 0) {
            shakeTimer -= Time.deltaTime;

            if(shakeTimer <= 0f) {
            //Timer over
            CinemachineBasicMultiChannelPerlin camperlin = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            camperlin.m_AmplitudeGain = 0f;
        }
      }      
    }
}
