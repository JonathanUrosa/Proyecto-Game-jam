using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputController : MonoBehaviour
{
    private Camera _camera;
    public Camera _Camera => _camera;


    [SerializeField]ChannelInputSO channelInputSO;

    [SerializeField] float distanceRaycast = 1f;

    private void Start()
    {
        _camera = Camera.main;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var pos3D = _camera.ScreenPointToRay(Input.mousePosition).GetPoint(distanceRaycast);  
            channelInputSO.InvokeMouseDown(pos3D);
        }    
    }
}
