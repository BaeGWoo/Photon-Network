using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using JetBrains.Annotations;


public class RoomManager : MonoBehaviourPunCallbacks
{
    //[SerializeField] Button roomCreateButton;
    [SerializeField] InputField roomTitleInputField;
    [SerializeField] InputField roomCapacityInputField;
    [SerializeField] Transform contentTransform;
    private Dictionary<string, GameObject> dictionary = new Dictionary<string, GameObject>();



    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game Scene");
    }

    public void OnCreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();

        roomOptions.MaxPlayers = byte.Parse(roomCapacityInputField.text);
        roomOptions.IsOpen = true;
        roomOptions.IsVisible = true;
        PhotonNetwork.CreateRoom(roomTitleInputField.text, roomOptions);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        GameObject temporaryRoom;

        foreach(RoomInfo roomInfo in roomList)
        {
            if (roomInfo.RemovedFromList == true)
            {
                dictionary.TryGetValue(roomInfo.Name, out temporaryRoom);
                Destroy(temporaryRoom);
                dictionary.Remove(roomInfo.Name);
            }

            else
            {
                if (dictionary.ContainsKey(roomInfo.Name) == false)
                {
                    GameObject roomObject= Instantiate(Resources.Load<GameObject>("Room"),contentTransform);

                    roomObject.GetComponent<Information>().SetData
                    (
                        roomInfo.Name,
                        roomInfo.PlayerCount,
                        roomInfo.MaxPlayers
                    );

                    dictionary.Add(roomInfo.Name, roomObject);
                }

                else
                {
                    dictionary.TryGetValue(roomInfo.Name, out temporaryRoom);
                    temporaryRoom.GetComponent<Information>().SetData
                    (
                        roomInfo.Name,
                        roomInfo.PlayerCount,
                        roomInfo.MaxPlayers

                    );
                }
            }
        }

        // �� ���� 
        //RemoveRoom();

        // �� ������Ʈ
        //UpdateRoom();

        // �� ����
        //InstantiateRoom();
        
    }

    //public void InstantiateRoom()
    //{
    //    foreach(RoomInfo roomInfo in dictionary.Values)
    //    {
    //        // 1. Room ������Ʈ �����մϴ�.
    //        GameObject room=Instantiate(Resources.Load<GameObject>("Room"));
    //
    //        // 2. room ������Ʈ�� ��ġ ���� �����մϴ�.
    //        room.transform.SetParent(contentTransform);
    //
    //        // 3. room ������Ʈ �ȿ� �ִ� Text �Ӽ��� �����մϴ�.
    //        room.GetComponent<Information>().SetData(roomInfo.Name, roomInfo.PlayerCount, roomInfo.MaxPlayers);
    //    }
    //}


}
