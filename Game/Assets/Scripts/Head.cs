using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rotation))]
public class Head : MonoBehaviour
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
        rotation.RotateX();
    }
}
