using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] ChannelCameraSO channelCamera;
    [SerializeField] CinemachineVirtualCamera cinemachineVirtual;
    CinemachineOrbitalTransposer orbital;   
    float biasTarget;
    [SerializeField]float speed = 1;
    [SerializeField] AudioListener audioListener;
    private void OnEnable()
    {
        channelCamera.OnEventTarget += TargetListener;
        channelCamera.OnEventRotate += RotateListener;
        orbital = cinemachineVirtual.GetCinemachineComponent<CinemachineOrbitalTransposer>();
    }
    private void OnDisable()
    {
        channelCamera.OnEventTarget -= TargetListener;
        channelCamera.OnEventRotate -= RotateListener;
    }
    private void TargetListener(Transform target)
    {
        cinemachineVirtual.Follow = target;
        cinemachineVirtual.LookAt = target;
        audioListener.enabled = false;
    }
    private void Update()
    {
        orbital.m_Heading.m_Bias = Mathf.Lerp(orbital.m_Heading.m_Bias, biasTarget, Time.smoothDeltaTime * speed);
    }

    private void RotateListener(bool Next)
    {
        if (Next)
        {
            biasTarget -= 45f;

        }
        else
        {
            biasTarget += 45f;
        }
    }
}
