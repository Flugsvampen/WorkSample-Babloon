using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 20f;

    private Transform target;

    
    void Start()
    {
        target = transform.parent;
    }

    
    void Update()
    {
        float rotateDegreesX = 0f;
        
        rotateDegreesX += Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;

        transform.RotateAround(target.position, Vector3.up, rotateDegreesX);
    }
}