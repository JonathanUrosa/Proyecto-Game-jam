using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BinderAnimator : MonoBehaviour
{
    [SerializeField] UnityEvent OnEventAttackComplete;
    public void AttackComplete()
    {
        OnEventAttackComplete?.Invoke();    
    }
}
