using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    [SerializeField] ChannelInputSO channelInput;
    [SerializeField] NavMeshAgent agent;

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
        agent.SetDestination(position);
    }

    private void Move()
    {

    }

    private void Rotate()
    {

    }
}
