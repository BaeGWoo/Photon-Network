using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class CharacterSpawnerManager : MonoBehaviourPunCallbacks
{
    private void Awake()
    {
        Create();
    }

    public void Create()
    {
        PhotonNetwork.Instantiate
        (
            "Character",
            new Vector3(0, 1, 0),
            Quaternion.identity
        );
    }
}
