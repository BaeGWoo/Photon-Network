using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class UnitSpawnerManager : MonoBehaviourPunCallbacks
{
    [SerializeField] Transform spawnerPosition;
    WaitForSeconds waitForSeconds=new WaitForSeconds(5);


    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            StartCoroutine(CreateUnit());
        }
    }

    IEnumerator CreateUnit()
    {
        while (true)
        {
            PhotonNetwork.InstantiateRoomObject("Unit", spawnerPosition.position,Quaternion.identity);
            yield return waitForSeconds;
        }
    }

}
