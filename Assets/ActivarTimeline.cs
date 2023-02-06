using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ActivarTimeline : MonoBehaviour
{
    [SerializeField] PlayableDirector playableDirector;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            playableDirector.Play();
        }    
    }
}
