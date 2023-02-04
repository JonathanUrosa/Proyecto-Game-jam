using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{

    #region Field
    [SerializeField] ChannelNavmeshSO ChannelNavmeshSO; /// canal donde se obtiene la posicion y objetivo que debe seguir
    [SerializeField] SystemCombat systemCombat;
    [SerializeField] NavMeshAgent agent; // cache del agente
    [SerializeField] ParticleSystem particleMove; // particula de moviemiento
    [SerializeField] StateCharacter stateCharacter; // visualizacion de estado
    [SerializeField] float DistanceLimitTarget; // distancia maxima que puede tener de cercania con el objetivo
    [SerializeField] float DistanceMin; // distancia minima para entender que ya llego a su punto solicitado
    #endregion

    private Vector3 destine;// cache del destino hacia donde se dirige el character
    [SerializeField] private Interactable CurrentInteractable;// el interactuable actual hacia donde se dirige el player

    #region Property

    /// <summary>
    ///  obtiene verdadero si el player esta moviendose actualmente
    /// </summary>
    public bool IsMove { get { return stateCharacter == StateCharacter.Move;  } }

    /// <summary>
    ///  obtiene la distancia actual del objetivo del player y el player
    /// </summary>
    public float DistanceDestine { get { return Vector3.Distance(transform.position, destine) - 0.5f; } }
    #endregion


    #region Methods

    private void OnEnable()
    {
        ChannelNavmeshSO.OnEventPoint += MoveListener; // suscripcion
        ChannelNavmeshSO.OnEventInteractable += MovementInteractableListener;// suscripcion
    }
    private void OnDisable()
    {
        ChannelNavmeshSO.OnEventPoint -= MoveListener; 
        ChannelNavmeshSO.OnEventInteractable -= MovementInteractableListener;
    }
    /// <summary>
    ///  es metodo es un oyente de cuando se hace click en el mundo, mayormente en el suelo
    /// </summary>
    /// <param name="position"></param>
    public void MoveListener(Vector3 position)
    {
        CurrentInteractable = null;
        InvokeMovement(position);
    }

    /// <summary>
    ///  es metodo es un oyente de cuando se hace click en un objeto interactuable
    /// </summary>
    /// <param name="position"></param>
    public void MovementInteractableListener(Interactable interactable)
    {
        CurrentInteractable = interactable;
        var dir = -GetDirection(CurrentInteractable.GetReturnPoint());
        var offset = dir * DistanceLimitTarget;
        offset.y = 0;
        var pos = CurrentInteractable.GetReturnPoint() + offset;
        InvokeMovement(pos);
    }
    public void InvokeMovement(Vector3 position)
    {
        destine = position;
        agent.SetDestination(destine);
        InvokeMove();
    }
    private void Update()
    {
        if (IsMove) // si se esta moviento
        {
            if (DistanceDestine <= DistanceMin) // evalue si la distancia con el destino ya es la necesaria
            {
                if(CurrentInteractable != null) // evalue si su objetivo era un interactuable
                {
                    LookTarget();
                    InvokeIdle();
                    systemCombat.InvokeAttack(CurrentInteractable);
                    // Mirar hacia el interactuable
                    // Evaluar el tipo de interactuable. 

                    /// si el interactuable es para hacerle daño
                    /// para agarrar algo
                    ///  o para hacer una animacion y activar algo
                }
                else
                {
                    InvokeIdle(); // detengase
                }
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

    private void LookTarget()
    {
        var dir = GetDirection(CurrentInteractable.GetReturnPoint());
        transform.rotation = Quaternion.LookRotation(dir);
    }
    private Vector3 GetDirection(Vector3 destine)
    {
        var dir = destine - transform.position;
        dir.y = transform.position.y;
        return dir.normalized;
    }
    #endregion
}
public enum StateCharacter
{
    Idle,
    Move,
    Attack,
}

