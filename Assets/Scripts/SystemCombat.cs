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
            if (curretInteractable.TryGetComponent(out Damageable damageable))
            {
                if(damageable.endurance > 0)
                {
                    animator.SetBool(IdAttack, true);
                }
            }
        }
    }
    public void CancelAttack()
    {
        curretInteractable = null;
        animator.SetBool(IdAttack, false);
    }
    public void AttackComplete()
    {
        Debug.Log("ataque completo");
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
        Debug.Log("RPC ataque completo");
        interactablesManager.GetInteractable(id).InvokeInteractable();
        //curretInteractable.InvokeInteractable();        // causar dano al interactuable
    }
}
