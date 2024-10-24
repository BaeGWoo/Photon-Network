using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;


public class View : MonoBehaviourPunCallbacks
{
    [SerializeField] Text nickName;
    [SerializeField] Camera romoteCamera;
    void Start()
    {
        nickName.text=photonView.Owner.NickName;
    }

    // Update is called once per frame
    void Update()
    {      
        transform.forward= romoteCamera.transform.forward;

        //Vector3 eulerRotation = transform.eulerAngles;
        //eulerRotation.x = 0; // X�� ȸ�� ����
        //eulerRotation.z = 0; // Z�� ȸ�� ����
        //nickName.transform.eulerAngles = eulerRotation;
    }
}
