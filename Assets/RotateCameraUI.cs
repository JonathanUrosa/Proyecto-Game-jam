using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class RotateCameraUI : MonoBehaviour
{
    [SerializeField]ChannelCameraSO channelCamera;


    public void NextRotate()
    {
        channelCamera.InvokeRotate(true);
    }

    public void BackRotate()
    {
        channelCamera.InvokeRotate(false);
    }
}
