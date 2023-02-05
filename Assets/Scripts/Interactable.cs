using System;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField] ChannelNavmeshSO channelNavmeshSO;
    [SerializeField] Transform pointTarget;// punto de referencia que tendra los character para poder interactuar con este objeto
    [HideInInspector]public Damageable damageable; 
    [SerializeField] UnityEvent OnEventInit = new UnityEvent(); // este evento va a contener el conjunto de acciones que deberan suceder inicio
    [SerializeField] UnityEvent onEventSelect = new UnityEvent(); // este evento va a contener el conjunto de acciones que deberan suceder al ser seleccionado
    [SerializeField] UnityEvent onEventDeselect = new UnityEvent();// este evento va a contener el conjunto de acciones que deberan suceder al ser deseleccionado
    [SerializeField] UnityEvent onEventInteractable = new UnityEvent();// este evento va a contener el conjunto de acciones que deberan suceder al character interactual con el

    public UnityEvent OnEventDeselect { get => onEventDeselect; set => onEventDeselect = value; }
    public UnityEvent OnEventSelect { get => onEventSelect; set => onEventSelect = value; }
    public UnityEvent OnEventInteractable { get => onEventInteractable; set => onEventInteractable = value; }


    private void OnEnable()
    {
        damageable = GetComponent<Damageable>();
        OnEventInit?.Invoke();
        channelNavmeshSO.OnEventInteractable += EventInteractableListener;
    }
    private void OnDisable()
    {
        channelNavmeshSO.OnEventInteractable -= EventInteractableListener;
    }

    public virtual void EventInteractableListener(Interactable interactable)
    {
        if (interactable == this)
        {
            Select();
        }
        else
        {
            Deselect();
        }
    }
    /// <summary>
    ///  este metodo sera llamado al seleccionar un objeto interactuable
    /// </summary>
    public virtual void Select()
    {
        OnEventSelect?.Invoke();
    }
    /// <summary>
    ///  este metodo sera llamado al apretar cualquier otro punto que no sea este objeto interactuable
    /// </summary>
    public virtual void Deselect()
    {
        OnEventDeselect?.Invoke();
    }
    /// <summary>
    ///  este metodo retornara la posiciion que debe tener el player para poder interactuar con este objeto
    /// </summary>
    /// <returns></returns>
    public Vector3 GetReturnPoint()
    {
        return pointTarget.transform.position;
    }
    public virtual void InvokeInteractable()
    {
        onEventInteractable?.Invoke();
    }
}

