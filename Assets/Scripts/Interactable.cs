using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField] ChannelNavmeshSO channelNavmeshSO;
    [SerializeField] Transform pointTarget;// punto de referencia que tendra los character para poder interactuar con este objeto

    [SerializeField] UnityEvent OnEventInit = new UnityEvent(); // este evento va a contener el conjunto de acciones que deberan suceder inicio
    [SerializeField] UnityEvent OnEventSelect = new UnityEvent(); // este evento va a contener el conjunto de acciones que deberan suceder al ser seleccionado
    [SerializeField] UnityEvent OnEventDeselect = new UnityEvent();// este evento va a contener el conjunto de acciones que deberan suceder al ser deseleccionado
    [SerializeField] UnityEvent OnEventInteractable = new UnityEvent();// este evento va a contener el conjunto de acciones que deberan suceder al character interactual con el


    bool IsSelect = false;
    private void OnEnable()
    {
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
        if (IsSelect) return;
        OnEventSelect?.Invoke();
        IsSelect = true;
    }
    /// <summary>
    ///  este metodo sera llamado al apretar cualquier otro punto que no sea este objeto interactuable
    /// </summary>
    public virtual void Deselect()
    {
        if (!IsSelect) return;
        OnEventDeselect?.Invoke();
        IsSelect = false;
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
        OnEventInteractable?.Invoke();
    }
}

