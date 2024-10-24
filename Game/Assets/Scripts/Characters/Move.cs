using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class Move : MonoBehaviour
{

    [SerializeField] float speed=5.0f;
    [SerializeField] Vector3 direction;

    public void Movement(Rigidbody rigidbody)
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");
        direction.Normalize();

        rigidbody.position+= rigidbody.transform.TransformDirection(direction * speed * Time.deltaTime);
    }


}
