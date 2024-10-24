using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Chat;
using UnityEngine.UI;

public class DialogManager : MonoBehaviourPunCallbacks
{
    [SerializeField] InputField inputField;
    [SerializeField] Transform parentTrasform;


    void Update()
    {
      if(Input.GetKeyDown(KeyCode.Return))
        {
            inputField.ActivateInputField();
            if (inputField.text.Length <= 0) return;
            
            // inputField�� �ִ� �ؽ�Ʈ�� �����ɴϴ�.
            string talk=photonView.Owner.NickName+ " : " + inputField.text;

            // RPC Target.All : ���� �뿡 �ִ� ��� Ŭ���̾�Ʈ���� Talk �Լ��� �����϶�� ����� �մϴ�.
            photonView.RPC("Talk", RpcTarget.All, talk);

        }  
    }
    [PunRPC]
    public void Talk(string message)
    {
        // Prefab�� �ϳ� ������ ���� text���� �����մϴ�.
        GameObject talk = Instantiate(Resources.Load<GameObject>("String"));

        talk.GetComponent<Text>().text=message;

        // ��ũ�� �� - content�� �ڽ����� ����մϴ�.
        talk.transform.SetParent(parentTrasform);

        // ä���� �Է��� �Ŀ��� �̾ �Է��� �� �ֵ��� �����մϴ�.
        inputField.ActivateInputField();

        // inputField�� �ؽ�Ʈ�� �ʱ�ȭ�մϴ�.
        inputField.text = "";
    }
}
