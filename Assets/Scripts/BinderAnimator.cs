using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BinderAnimator : MonoBehaviour
{
    [SerializeField] UnityEvent OnEventAttackComplete;
    [SerializeField] UnityEvent OnEventFootStep;
    public void AttackComplete()
    {
        OnEventAttackComplete?.Invoke();    
    }
    public void FootStep()
    {
        OnEventFootStep?.Invoke();
    }
}
