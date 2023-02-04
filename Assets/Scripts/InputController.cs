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

    Vector3 PosCamera = Vector3.zero;
    [SerializeField] LayerMask layerMask;

    private void Start()
    {
        _camera = Camera.main;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out RaycastHit hit);
            PosCamera = hit.point;
            channelInputSO.InvokeMouseDown(PosCamera);
        }    
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(PosCamera, 1);
    }
}
