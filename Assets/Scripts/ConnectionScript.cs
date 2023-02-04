using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.UI;
using Photon.Realtime;

public class ConnectionScript : MonoBehaviourPunCallbacks
{
    public TMP_InputField nicknameField;
    public TMP_Text ButtonText;
    public Button loginButton;
    public GameObject characterPrefab;
    GameObject[] spawners;
    Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
        nicknameField.text = PlayerPrefs.GetString("nickName");
        spawners = GameObject.FindGameObjectsWithTag("Spawners");
    }
    public override void OnEnable()
    {
        base.OnEnable();
        loginButton.onClick.AddListener(OnClickConnect);
    }
    public override void OnDisable()
    {
        base.OnDisable();
        loginButton.onClick.RemoveListener(OnClickConnect);
    }
    public void OnClickConnect()
    {
        
        if (nicknameField.text.Length >= 1){
            PhotonNetwork.NickName = nicknameField.text;
            PlayerPrefs.SetString("nickName", nicknameField.text);
            ButtonText.text = "connecting";
            PhotonNetwork.ConnectUsingSettings();
            loginButton.interactable = false;
        }
    }
    public override void OnConnectedToMaster()
    {
        ButtonText.text = "Entering to lobby";
        base.OnConnectedToMaster();
        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedLobby()
    {
        ButtonText.text = "Entering To Room";
        RoomOptions roomOptions = new()
        {
            IsVisible = false,
            MaxPlayers = 20
        };
        PhotonNetwork.JoinOrCreateRoom("GameJam", roomOptions, TypedLobby.Default);
    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        StartCoroutine("EnteringEvents");
    }
    public IEnumerator EnteringEvents() {
        var randomPos = spawners[Random.Range(0,spawners.Length)];
        PhotonNetwork.Instantiate(characterPrefab.name, randomPos.transform.position,Quaternion.identity);

        yield return new WaitForSeconds(3);
        canvas.enabled = false;
    }
}
