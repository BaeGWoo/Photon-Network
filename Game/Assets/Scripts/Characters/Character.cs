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
    [SerializeField] Rigidbody rigidbody;


    private void Awake()
    {
        move=GetComponent<Move>();
        rotation=GetComponent<Rotation>();
        rigidbody=GetComponent<Rigidbody>();
    }

    void Start()
    {
        DisableCamera();
    }

    private void Update()
    {
        if (photonView.IsMine == false) return;


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MouseManager.Instance.SetMouse(true);
        }


        rotation.InputRotateY();
    }

    void FixedUpdate()
    {
        if (photonView.IsMine == false) return;
        move.Movement(rigidbody);
        rotation.RotateY(rigidbody);
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
