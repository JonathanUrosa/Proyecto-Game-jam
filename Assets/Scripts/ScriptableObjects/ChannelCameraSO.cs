using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "ScriptableObjects/Channels/CameraSO")]
public class ChannelCameraSO : ScriptableObject
{
    public UnityAction<Transform> OnEventTarget { get; set; }
    public UnityAction<bool> OnEventRotate { get; set; }

    public void InvokeChangeTarget(Transform transform)
    {
        OnEventTarget?.Invoke(transform);   
    }

    public void InvokeRotate(bool v)
    {
        OnEventRotate?.Invoke(v);
    }
}

