using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablesManager : MonoBehaviour
{
    public List<Interactable> interactables;    

    public int GetInteractable(Interactable interactable)
    {
        for (int i = 0; i < interactables.Count; i++)
        {
            if(interactable == interactables[i])
            {
                return i;   
            }
        }
        return 0;
    }
    public Interactable GetInteractable(int index)
    {
        return interactables[index];
    }
}
