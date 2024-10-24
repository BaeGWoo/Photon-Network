using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.UI;
public class LobbyManager : MonoBehaviourPunCallbacks 
{
    [SerializeField] Canvas lobbyCanvas;
    [SerializeField] Dropdown dropdown;
    [SerializeField] GameObject popUp;
    private void Awake()
    {
        PhotonNetwork.NickName=(PlayerPrefs.GetString("NickName"));

        if (string.IsNullOrEmpty(PlayerPrefs.GetString("NickName")))
        {
            popUp.SetActive(true);
        }

        else
        {
            Debug.Log(PlayerPrefs.GetString("NickName")+"님 환영합니다.");
        }
        if (PhotonNetwork.IsConnected)
        {
            lobbyCanvas.gameObject.SetActive(false);
        }
    }

    public void Connect()
    {
        // 서버에 접속하는 함수
        PhotonNetwork.ConnectUsingSettings();

        lobbyCanvas.gameObject.SetActive(false);

    }

    public override void OnJoinedLobby()
    {
        if (lobbyCanvas.gameObject.activeSelf)
            lobbyCanvas.gameObject.SetActive(true);
    }

    public override void OnConnectedToMaster() 
    {
        // JoinLobby : 특정 로비를 생성하여 진입하는 함수
        PhotonNetwork.JoinLobby
        (
            new TypedLobby
            (
                dropdown.options[dropdown.value].text,
                LobbyType.Default
            )
        );
    }
}
