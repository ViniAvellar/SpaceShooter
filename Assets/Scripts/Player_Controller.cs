using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {

	public float speed;
	
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
	}
	
}
