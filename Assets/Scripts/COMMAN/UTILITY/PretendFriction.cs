using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PretendFriction : MonoBehaviour {


	private Rigidbody myBody;
	private Transform myTransform;
	private float myMass;
	private float slideSpeed;
	private Vector3 velo;
	private Vector3 flatVelo;
	private Vector3 myRight;
	private Vector3 TEMPvec3;

	public float theGrip=100f;
	// Use this for initialization
	void Start () {

		myBody = rigidbody;
		myMass = myBody.mass;
		myTransform = transform;


	}
	void FixedUpdate()
	{
		myRight = myTransform.right;
		velo = myBody.velocity;
		flatVelo.x = velo.x;
		flatVelo.y = 0;
		flatVelo.z = velo.z;
		slideSpeed = Vector3.Dot (myRight,flatVelo);

		TEMPvec3 = myRight * (-slideSpeed * myMass * theGrip);
	
		myBody.AddForce (TEMPvec3 * Time.deltaTime);
	

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
