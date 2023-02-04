using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemCombat : MonoBehaviour
{
    [SerializeField] Animator animator;
    Interactable curretInteractable;

    readonly int IdAttack = Animator.StringToHash("Attack");

    public void InvokeAttack(Interactable interactable)
    {
        curretInteractable = interactable;
        animator.SetBool(IdAttack, true);   
    }
    public void CancelAttack()
    {
        curretInteractable = null;
        animator.SetBool(IdAttack, false);
    }
    public void AttackComplete()
    {
        if(curretInteractable != null)
        {
            curretInteractable.InvokeInteractable();        // causar dano al interactuable
        }
        CancelAttack();
    }
}
