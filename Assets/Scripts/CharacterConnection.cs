using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CharacterConnection : MonoBehaviourPun
{
    public CinemachineVirtualCamera virtualCamera;
    private void OnEnable()
    {
        virtualCamera = GameObject.FindGameObjectWithTag("PlayerCam").GetComponent<CinemachineVirtualCamera>();
        if (photonView.IsMine && PhotonNetwork.IsConnectedAndReady)
        {

        }
    }

}
