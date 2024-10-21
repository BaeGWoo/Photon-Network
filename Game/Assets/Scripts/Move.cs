using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class Move : MonoBehaviour
{

    [SerializeField] float speed=5.0f;
    [SerializeField] Vector3 direction;

    public void Movement()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");
        direction.Normalize();

        transform.position+=transform.TransformDirection(direction * speed * Time.deltaTime);
    }


}
