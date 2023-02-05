using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]
public class AxeScript : MonoBehaviour
{
    public AxeSO axeScriptableObject;
    Interactable interactable;
    private void Awake()
    {
        interactable = GetComponent<Interactable>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hacha interactiva por trigger- "+other.name);
        if(other.CompareTag("Player"))
        {
            interactable.InvokeInteractable();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hacha interactiva por collider- " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player"))
        {
            interactable.InvokeInteractable();
        }
    }
}
