using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}
public class Player_Controller : MonoBehaviour {

	public float speed;
    public float tilt;
    public Boundary boundary;

	private Rigidbody myRigidbody;
	
	void Start()
	{
		myRigidbody = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		
		
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
		
		//myRigidbody.velocity = new Vector3(x, y, z);
		myRigidbody.velocity = new Vector3(horizontal * speed, 0.0f, vertical * speed);
		
		Debug.Log("h: " + horizontal + ", v: " + vertical);

        myRigidbody.position = new Vector3
            (
            Mathf.Clamp(myRigidbody.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(myRigidbody.position.z, boundary.zMin, boundary.zMax)
            );
        myRigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, myRigidbody.velocity.x * -tilt);
	}
	
}
