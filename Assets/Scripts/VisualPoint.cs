using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualPoint : MonoBehaviour
{
    [SerializeField] ChannelNavmeshSO channelNavMeshSO;
    [SerializeField] ParticleSystem _particleSystem;

    private void OnEnable()
    {
        channelNavMeshSO.OnEventPoint += DrawPoint;
        channelNavMeshSO.OnEventInteractable += CancelDraw;
        CancelDraw(null);
    }
    private void OnDisable()
    {
        channelNavMeshSO.OnEventPoint -= DrawPoint;
        channelNavMeshSO.OnEventInteractable -= CancelDraw;
    }
    private void CancelDraw(Interactable arg0)
    {
        _particleSystem.transform.gameObject.SetActive(false);
        _particleSystem.Pause();
    }
    private void DrawPoint(Vector3 arg0)
    {
        _particleSystem.transform.position = new Vector3(arg0.x, -0.5f,arg0.z);
        _particleSystem.transform.gameObject.SetActive(true);
        _particleSystem.Play();
    }
}
