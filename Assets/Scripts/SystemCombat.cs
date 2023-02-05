using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemCombat : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] PhotonView photonView;
    InteractablesManager interactablesManager;
    Interactable curretInteractable;

    readonly int IdAttack = Animator.StringToHash("Attack");
    readonly string AttackString = "Attack";

    private void Awake()
    {
        interactablesManager = FindObjectOfType<InteractablesManager>();
    }

    public void InvokeAttack(Interactable interactable)
    {
        curretInteractable = interactable;
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName(AttackString))
        {
            animator.SetBool(IdAttack, true);
        }
    }
    public void CancelAttackForce()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName(AttackString))
        {
            curretInteractable = null;
            animator.SetBool(IdAttack, false);
            animator.Play("Run");
        }
    }
    public void CancelAttack()
    {
        curretInteractable = null;
        animator.SetBool(IdAttack, false);
    }
    public void AttackComplete()
    {
        if (photonView.IsMine)
        {
            if (curretInteractable != null)
            {
                curretInteractable.InvokeInteractable();        // causar dano al interactuable
                photonView.RPC(nameof(RPCAttackComplete), RpcTarget.Others, interactablesManager.GetInteractable(curretInteractable));
            }
            CancelAttack();
        }
    }
    [PunRPC]
    public void RPCAttackComplete(int id)
    {
        interactablesManager.GetInteractable(id).InvokeInteractable();
        //curretInteractable.InvokeInteractable();        // causar dano al interactuable
    }
}
