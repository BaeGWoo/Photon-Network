using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;


public class Information : MonoBehaviourPunCallbacks
{
    private string roomTitle;
    [SerializeField] Text roomTitleText;
   
    public void OnConnectRoom()
    {
        PhotonNetwork.JoinRoom(roomTitle);
    }

    public void SetData(string name,int currentStaff,int MaxStaff)
    {
        roomTitle = name;

        roomTitleText.text = roomTitle + "( " + currentStaff + " / " + MaxStaff + " )";
         
    }
}
