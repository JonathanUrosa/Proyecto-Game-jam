using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "ScriptableObjects/Channels/CameraSO")]
public class ChannelCameraSO : ScriptableObject
{
    public UnityAction<Transform> OnEventTarget { get; set; }

    public void InvokeChangeTarget(Transform transform)
    {
        OnEventTarget?.Invoke(transform);   
    }
}

