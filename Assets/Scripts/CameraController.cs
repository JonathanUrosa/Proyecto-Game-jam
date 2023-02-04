using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] ChannelCameraSO channelCamera;
    [SerializeField] CinemachineVirtualCamera cinemachineVirtual;

    private void OnEnable()
    {
        channelCamera.OnEventTarget += TargetListener;
    }
    private void OnDisable()
    {
        channelCamera.OnEventTarget -= TargetListener;
    }
    private void TargetListener(Transform target)
    {
        cinemachineVirtual.Follow = target;
        cinemachineVirtual.LookAt = target;
    }
}
