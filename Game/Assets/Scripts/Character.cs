using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(Move))]
[RequireComponent(typeof(Rotation))]
public class Character : MonoBehaviourPun
{
    [SerializeField] Camera remoteCamera;
    [SerializeField] Move move;
    [SerializeField] Rotation rotation;

    private void Awake()
    {
        move=GetComponent<Move>();
        rotation=GetComponent<Rotation>();

    }

    void Start()
    {
        DisableCamera();
    }

    void Update()
    {
        move.Movement();
        rotation.RotateY();
    }

    public void DisableCamera()
    {
        if (photonView.IsMine)
        {
            Camera.main.gameObject.SetActive(false);  
        }

        else
        {
            remoteCamera.gameObject.SetActive(false);
        }
    }
}
