using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform targetObject;
    public float smoothness;
    private Vector3 initialOffset;
    private Vector3 cameraPosition;

    void Start()
    {
        targetObject = GameObject.Find("Jumper(Clone)").transform;
        initialOffset = transform.position - targetObject.position;
    }


    void FixedUpdate()
    {
        cameraPosition = initialOffset;
        //cameraPosition = targetObject.position + initialOffset;
        cameraPosition += targetObject.position;
        transform.position = Vector3.Lerp(transform.position, cameraPosition, smoothness * Time.fixedDeltaTime);
    }
}
