using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class NavMeshController : MonoBehaviour
{
    [SerializeField] ChannelInputSO channelInput;
    [SerializeField] ChannelNavmeshSO channelNavmesh;
    Vector3 destine;
    [SerializeField] float RadiusClick;
    [SerializeField] LayerMask LayerInteractable;
    Collider[] colliders;


    Interactable cacheInteractable;
 
    private void OnEnable()
    {
        channelInput.OnEventMouseDown += InvokeMovement;
    }

    private void OnDisable()
    {
        channelInput.OnEventMouseDown -= InvokeMovement;
    }
    /// <summary>
    /// Este metodo recibe donde se ha hecho click en el mundo
    /// </summary>
    /// <param name="arg0"></param>
    private void InvokeMovement(Vector3 arg0)
    {
        if (NavMesh.SamplePosition(arg0, out NavMeshHit hit, 10, NavMesh.AllAreas))// evalua las posiciones del navmesh para confirmaar que todo es correcto
        {
            destine = hit.position;

            colliders = Physics.OverlapSphere(destine, RadiusClick, LayerInteractable); // evalua si hay objetos interactuable en esa zona
            destine.y = 0;

            if (colliders.Length > 0)
            {
                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].TryGetComponent(out Interactable interactable))// confirma que esos objetos tenga el interactable
                    {
                        cacheInteractable = interactable; // guardo una referencia para luego ser usada para deseleccionarla
                        channelNavmesh.InvokeInteracble(cacheInteractable);// invoka el interactuable seleccionado para que el character y el objeto sepan
                        return;
                    }
                }
                DeselectLastInteractable();
                channelNavmesh.InvokePoint(destine); // si no encontro a un objeto interactuable pues envia el punto mas cercano
            }
            else
            {
                DeselectLastInteractable();
                channelNavmesh.InvokePoint(destine);// si no encontro a un objeto interactuable pues envia el punto mas cercano
            }    
        }
    }
    /// <summary>
    ///  este metodo deseleccionara el interactuable que estaba seleccionado anteriormente
    /// </summary>
    private void DeselectLastInteractable()
    {
        if(cacheInteractable != null)
        {
            cacheInteractable.Deselect();
            cacheInteractable = null;
        }
    }
}
