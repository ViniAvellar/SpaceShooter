using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    private Rigidbody myRigidbody;
    void Start ()
    {
        myRigidbody = GetComponent<Rigidbody>();
        myRigidbody.velocity = transform.forward * speed;
    }
}
