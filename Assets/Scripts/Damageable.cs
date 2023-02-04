using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    public int totalEndurance=3,endurance = 3;
    [SerializeField] UnityEvent onEventHit;
    [SerializeField] UnityEvent onEventDestroy;

    public UnityEvent OnEventHit { get => onEventHit; set => onEventHit = value; }
    public UnityEvent OnEventDestroy { get => onEventDestroy; set => onEventDestroy = value; }

    public void InvokeHit()
    {
        endurance--;
        if(endurance > 0)
        {
            Hit();
        }
        else
        {
            Destroy();
        }
    }
    private void Hit()
    {
        OnEventHit?.Invoke();
    }

    private void Destroy()
    {
        OnEventDestroy?.Invoke();
    }
}
