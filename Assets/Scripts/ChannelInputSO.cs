using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "ScriptableObjects/Channels")]
public class ChannelInputSO : ScriptableObject
{
    public UnityAction<Vector3> OnEventMouseDown { get; set; }

    public void InvokeMouseDown(Vector3 pos)
    {
        OnEventMouseDown?.Invoke(pos);
    }
}
