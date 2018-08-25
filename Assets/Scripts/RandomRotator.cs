using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    public float tumble;
    private Rigidbody myRigidbody;
    void Start ()
    {
        myRigidbody = GetComponent<Rigidbody>();
        myRigidbody.angularVelocity = Random.insideUnitSphere * tumble;
    }
}
