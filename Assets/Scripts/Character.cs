using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{

    #region Field
    [SerializeField] ChannelInputSO channelInput;
    [SerializeField] StateCharacter stateCharacter;
    [SerializeField] float DistanceLimitTarget;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] ParticleSystem particleMove;
    #endregion

    private Vector3 destine;

    #region Property

    public bool IsMove { get { return stateCharacter == StateCharacter.Move;  } }

    public float DistanceDestine { get { return Vector3.Distance(transform.position, destine) - 0.5f; } }
    #endregion


    #region Methods

    private void OnEnable()
    {
        channelInput.OnEventMouseDown += InvokeMovement;
    }
    private void OnDisable()
    {
        channelInput.OnEventMouseDown -= InvokeMovement;
    }
    public void InvokeMovement(Vector3 position)
    {
        if(NavMesh.SamplePosition(position,out NavMeshHit hit, 10, NavMesh.AllAreas))
        {
            destine = hit.position;
            agent.SetDestination(destine);
            InvokeMove();
        }
    }
    private void Update()
    {
        if (IsMove)
        {
            if (DistanceDestine <= DistanceLimitTarget)
            {
                InvokeIdle();
            }
        }
    }
    private void InvokeIdle()
    {
        SetState(StateCharacter.Idle);
        particleMove.Stop();
    }
    private void InvokeMove()
    {
        SetState(StateCharacter.Move);
        particleMove.Play();
    }
    private void SetState(StateCharacter state)
    {
        stateCharacter = state;
    }
    #endregion
}
public enum StateCharacter
{
    Idle,
    Move,
    Attack,
}

