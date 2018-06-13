using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class VRController : MonoBehaviour
{
    public Transform cam;
    public float speed = 3;
    public float toggleAngle = 20;

    Rigidbody body;

    bool isMowing = false;

    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isMowing = cam.eulerAngles.x >= toggleAngle && cam.eulerAngles.x < 90;
        if (isMowing)
        {
            Vector3 forward = cam.TransformDirection(Vector3.forward);
            body.velocity = forward * speed;
        }


    }
}
