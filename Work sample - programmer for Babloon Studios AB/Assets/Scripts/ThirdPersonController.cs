using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;

    private Transform cameraTrans;
    private Vector3 cameraDirFwd;
    private Vector3 cameraDirSide;
    private float moveFwd;
    private float moveSide;


    void Start()
    {
        cameraTrans = transform.GetChild(0);
    }


    void Update()
    {
        // Gets direction of camera
        cameraDirFwd = transform.position - cameraTrans.position;
        cameraDirFwd.y = 0;
        cameraDirFwd.Normalize();

        // Gets sideways direction of camera
        cameraDirSide = Quaternion.Euler(0f, 90f, 0f) * cameraDirFwd;

        moveFwd = Input.GetAxis("Vertical");
        moveSide = Input.GetAxis("Horizontal");
        
        transform.Translate((cameraDirFwd * moveFwd + cameraDirSide * moveSide) * moveSpeed * Time.deltaTime);
    }
}
