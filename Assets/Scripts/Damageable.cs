using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    public int endurance = 3;
    [SerializeField] UnityEvent OnEventHit;
    [SerializeField] UnityEvent OnEventDestroy;

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
