using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "ScriptableObjects/Channels/AxeSO")]
public class AxeSO : ScriptableObject
{
    [HideInInspector]
    public int AxeEnduranceState;
    public UnityAction<int> OnUpdateAxe { get; set; }

    public void InvokeChangeTarget(int points)
    {
        OnUpdateAxe?.Invoke(points);
    }
}
