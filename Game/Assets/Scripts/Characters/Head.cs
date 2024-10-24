using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rotation))]
public class Head : MonoBehaviourPunCallbacks
{
    private Rotation rotation;
    // Start is called before the first frame update
    void Awake()
    {
        rotation=GetComponent<Rotation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine == false) return;
        rotation.RotateX();
    }
}
