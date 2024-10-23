using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;
using UnityEditor.UI;

public class NickName : MonoBehaviourPunCallbacks
{
    [SerializeField] Button button;
    [SerializeField] string nickName;
    [SerializeField] InputField inputField;
    static public NickName instance;
    public void SetName()
    {
        // 1. nickName�� inputField�� �Է��� ���� �����մϴ�.
        nickName = inputField.text;
        // 2. PhotonNetwork.NickName�� nickName ���� �־��ݴϴ�.
        PhotonNetwork.NickName=nickName;
        // 3. NickName�� �����մϴ�.
        PlayerPrefs.SetString("NickName",PhotonNetwork.NickName);
        // 4. �˾��� ��Ȱ��ȭ�մϴ�.
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (inputField.text.Length <= 0)
        {
            button.interactable = false;
        }

        else
            button.interactable = true;
    }
}