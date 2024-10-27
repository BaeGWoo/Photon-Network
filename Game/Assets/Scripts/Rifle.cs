using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Rifle : MonoBehaviourPunCallbacks
{
    [SerializeField] Ray ray;
    [SerializeField] RaycastHit rayCastHit;
    [SerializeField] Camera remoteCamera;
    [SerializeField] LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine == false) return;

        if (Input.GetMouseButtonDown(0))
        {
            ray = remoteCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out rayCastHit, Mathf.Infinity, layerMask))
            {
                PhotonView photonView = rayCastHit.collider.GetComponent<PhotonView>();

                if (photonView.IsMine)
                {
                    photonView.GetComponent<Rake>().Die();
                }
            }
        }
        
    }
}
