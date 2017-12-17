using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    [SerializeField] float moveSpd = 1f;
    [SerializeField] float jumpForce = 100f;

    private Transform cameraTrans;
    private Vector3 cameraDirFwd;
    private Vector3 cameraDirSide;
    private float moveFwd;
    private float moveSide;

    private Rigidbody rb;


    void Start()
    {
        cameraTrans = transform.GetChild(0);

        rb = GetComponent<Rigidbody>();
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
        
        transform.Translate((cameraDirFwd * moveFwd + cameraDirSide * moveSide).normalized * moveSpd * Time.deltaTime);
    }


    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump") && Physics.Raycast(transform.position, -Vector3.up, 1f))
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
    }
}
