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

        // 룸 삭제 
        //RemoveRoom();

        // 룸 업데이트
        //UpdateRoom();

        // 룸 생성
        //InstantiateRoom();
        
    }

    //public void InstantiateRoom()
    //{
    //    foreach(RoomInfo roomInfo in dictionary.Values)
    //    {
    //        // 1. Room 오브젝트 생성합니다.
    //        GameObject room=Instantiate(Resources.Load<GameObject>("Room"));
    //
    //        // 2. room 오브젝트의 위치 값을 설정합니다.
    //        room.transform.SetParent(contentTransform);
    //
    //        // 3. room 오브젝트 안에 있는 Text 속성을 설정합니다.
    //        room.GetComponent<Information>().SetData(roomInfo.Name, roomInfo.PlayerCount, roomInfo.MaxPlayers);
    //    }
    //}


}
