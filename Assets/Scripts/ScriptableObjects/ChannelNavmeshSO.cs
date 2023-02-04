using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "ScriptableObjects/Channels/NavmeshSO")]
public class ChannelNavmeshSO : ScriptableObject
{
    public UnityAction<Interactable> OnEventInteractable { get; set; }
    public UnityAction<Vector3> OnEventPoint { get; set; }

    public void InvokePoint(Vector3 pos)
    {
        OnEventPoint?.Invoke(pos);
    }
    public void InvokeInteracble(Interactable interactable)
    {
        OnEventInteractable?.Invoke(interactable);
    }
}

